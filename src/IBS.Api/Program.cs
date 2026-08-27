using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using Azure.Identity;
using IBS.Api.Middleware;
using IBS.Api.Security;
using IBS.Api.Swagger;
using IBS.Infrastructure;
using IBS.Infrastructure.Configuration;
using IBS.Infrastructure.Persistence;
using IBS.Modules.Delivery;
using IBS.Modules.Design;
using IBS.Modules.Finance;
using IBS.Modules.Procurement;
using IBS.Modules.Sales;
using IBS.Modules.UsersAccess;
using IBS.SharedKernel.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// --- configuration ----------------------------------------------------------------

// Secrets live in Key Vault and are reached with the managed identity of the App Service:
// connection strings, the ACS connection string and the storage key never appear in
// appsettings.json or in source control (spec section 1).
var keyVaultUri = builder.Configuration["KeyVault:Uri"];
if (!string.IsNullOrWhiteSpace(keyVaultUri))
{
    builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUri), new DefaultAzureCredential());
}

// Local development overrides from the git-ignored appsettings.Local.json at the repository
// root - the same file the EF tooling and the seed tool read, so all three agree on which
// database they are talking to. Absent in Azure, where Key Vault above supplies these values.
builder.Configuration.AddIbsLocalSettings();

// Re-applied after the local file so they still win: the host added them before it, and a
// later source takes precedence. Without this, an App Service setting or a one-off
// ConnectionStrings__IbsDatabase on the command line would be silently ignored.
builder.Configuration.AddEnvironmentVariables();
builder.Configuration.AddCommandLine(args);

// Application Insights refuses to start without a connection string, so it is registered only
// where one is configured - which is Azure, not a developer machine (spec section 1).
var appInsightsConnectionString =
    builder.Configuration["ApplicationInsights:ConnectionString"]
    ?? builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"];

if (!string.IsNullOrWhiteSpace(appInsightsConnectionString))
{
    builder.Services.AddApplicationInsightsTelemetry(options =>
        options.ConnectionString = appInsightsConnectionString);
}

// --- services ---------------------------------------------------------------------

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        // Enums travel as their names, so a payload stays readable and a reordered enum
        // cannot silently change meaning.
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddProblemDetails();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUser, CurrentUser>();

builder.Services.AddIbsInfrastructure(builder.Configuration);

builder.Services.AddUsersAccessModule(builder.Configuration);
builder.Services.AddSalesModule(builder.Configuration);
builder.Services.AddDesignModule(builder.Configuration);
builder.Services.AddDeliveryModule(builder.Configuration);
builder.Services.AddProcurementModule(builder.Configuration);
builder.Services.AddFinanceModule(builder.Configuration);

// Bearer token rather than a cookie: Prod splits the Angular app (a Static Web App) from this
// API onto two different origins sharing one root domain, and Dev stays bundled/same-origin
// with no custom domain at all. A token doesn't care which of those is true - the same code
// path authenticates both, where a cookie could only ever work for one of them.
builder.Services.AddOptions<JwtOptions>()
    .Bind(builder.Configuration.GetSection(JwtOptions.SectionName))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddSingleton<IJwtTokenService, JwtTokenService>();

var jwtOptions = builder.Configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>() ?? new JwtOptions();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtOptions.Audience,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SigningKey)),
            // Tighter than the 5-minute default: with no refresh token, the expiry should mean
            // what it says rather than silently extending the token's real usable lifetime.
            ClockSkew = TimeSpan.FromSeconds(30)
        };

        options.Events = new JwtBearerEvents
        {
            // Closes a gap the cookie era never actually solved either (see AccountStatusChecker's
            // doc): a token issued before an account was suspended stays cryptographically valid
            // until it expires. This re-checks the live status on every request, so a status
            // change takes effect within one token lifetime rather than "next time they log in."
            OnTokenValidated = async context =>
            {
                var employeeIdClaim = context.Principal?.FindFirstValue(CurrentUser.EmployeeIdClaim);

                if (!Guid.TryParse(employeeIdClaim, out var employeeId))
                {
                    context.Fail("Token carries no valid employee id.");
                    return;
                }

                var statusChecker = context.HttpContext.RequestServices.GetRequiredService<IAccountStatusChecker>();

                if (!await statusChecker.IsActiveAsync(employeeId, context.HttpContext.RequestAborted))
                {
                    context.Fail("This account is no longer active.");
                }
            }
        };
    });

// Signed in by default; the few public endpoints opt out with [AllowAnonymous].
builder.Services.AddAuthorizationBuilder()
    .SetFallbackPolicy(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build());

// A no-op on Dev: same-origin requests never trigger CORS at all, so an empty allow-list
// there has zero effect. Only Prod's split hosting needs this to actually allow anything -
// AllowCredentials() is deliberately not set, because a bearer token attached via a manual
// Authorization header is not a browser-ambient credential the way a cookie is, so the
// credentialed-CORS restrictions a cookie approach would have forced don't apply here.
var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [];

builder.Services.AddCors(cors => cors.AddPolicy("Frontend", policy =>
{
    policy.WithOrigins(allowedOrigins)
        .WithMethods("GET", "POST", "PUT", "PATCH", "DELETE")
        .WithHeaders("Authorization", "Content-Type");
}));

builder.Services.AddIbsSwagger();

var app = builder.Build();

// --- pipeline ---------------------------------------------------------------------

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    // Fast iteration on Dev/Test. On Prod, migrations are an explicit deploy step and are
    // never applied silently against production data (spec section 2).
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<IbsDbContext>();

    // Says out loud which database this is, so a connection string that quietly fell back to
    // the local default is obvious rather than mysterious. Never logs the credentials.
    var connection = db.Database.GetDbConnection();
    app.Logger.LogInformation(
        "Using database {Database} on {Server}.", connection.Database, connection.DataSource);

    await db.Database.MigrateAsync();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

// The built Angular app is served from wwwroot of this same App Service: one deployable,
// one App Service, one bill (spec section 1).
app.UseDefaultFiles();
app.UseStaticFiles();

// Ahead of the authorization middleware on purpose: the fallback policy below demands a
// signed-in employee for anything it reaches, and the API documentation is not an API call.
app.UseIbsSwagger();

// Ahead of authentication: a cross-origin preflight OPTIONS request never carries the
// Authorization header, so it must be let through before anything asks "who is this."
app.UseCors("Frontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Any non-API path falls through to the Angular entry point so client-side routing works.
// The shell itself is public; what it can show is decided by the API calls it then makes.
app.MapFallbackToFile("index.html").AllowAnonymous();

app.Run();

/// <summary>Exposed so an integration-test host can reference this entry point.</summary>
public partial class Program;
