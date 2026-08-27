
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace IBS.Api.Swagger;

/// <summary>
/// OpenAPI setup for the IBS API. The document is generated from the controllers and their
/// XML comments, so the spec sections quoted in the code become the published description.
/// </summary>
public static class SwaggerRegistration
{
    /// <summary>Identifier of the single document this API publishes.</summary>
    public const string DocumentName = "v1";

    /// <summary>Id of the security scheme the operation filter references.</summary>
    public const string SecuritySchemeId = "bearer";

    /// <summary>Registers Swagger generation and the filters that document the access rules.</summary>
    public static IServiceCollection AddIbsSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(DocumentName, new OpenApiInfo
            {
                Title = "IBS Backend Service",
                Version = "v1",
                Description = """
                    Module 1 (user management) of the IBS modular monolith.

                    **Access model.** There are no roles. What an employee may do is decided
                    entirely by the permissions granted to them, with one bypass: an employee
                    carrying the Super Admin flag passes every check.

                    **Two rules worth knowing before reading the endpoints:**

                    - `manage_users` reaches every account except the one belonging to the
                      Super Admin. Only the Super Admin may mutate that account.
                    - Granting `manage_permissions` or `view_sensitive_data` requires the caller
                      to already hold `manage_permissions` - `manage_users` alone is not enough.

                    **Authentication.** A bearer token, issued by `POST /api/auth/login`. Unlike a
                    cookie, this page will not attach it for you: call login, copy the
                    `accessToken` from the response, then click **Authorize** above and paste it
                    in. It stays attached across a page reload while exploring.
                    """,
                Contact = new OpenApiContact { Name = "IBS Engineering" }
            });

            // Bearer token rather than a cookie: Prod splits the frontend and this API onto two
            // origins sharing one root domain, and Dev has no custom domain at all - a token
            // authenticates both the same way, where a cookie could only ever work for one.
            options.AddSecurityDefinition(SecuritySchemeId, new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Description = "Paste the accessToken returned by POST /api/auth/login."
            });

            // XML docs from every project in the solution: the DTO summaries live in the module
            // assembly, not in the API assembly. Registered before the filters below, because
            // the XML comment filters set Description and would otherwise overwrite what the
            // filters append to it.
            foreach (var xml in Directory.GetFiles(AppContext.BaseDirectory, "IBS.*.xml"))
            {
                options.IncludeXmlComments(xml, includeControllerXmlComments: true);
            }

            options.OperationFilter<AuthResponsesOperationFilter>();
            options.OperationFilter<PermissionSummaryOperationFilter>();
            options.SchemaFilter<EnumDescriptionSchemaFilter>();

            options.DescribeAllParametersInCamelCase();
            options.SupportNonNullableReferenceTypes();
            options.UseAllOfToExtendReferenceSchemas();
            options.CustomOperationIds(api => api.ActionDescriptor.RouteValues["action"] is { } action
                ? $"{api.ActionDescriptor.RouteValues["controller"]}_{action}"
                : null);
        });

        return services;
    }

    /// <summary>Serves the OpenAPI document and the Swagger UI at <c>/swagger</c>.</summary>
    public static WebApplication UseIbsSwagger(this WebApplication app)
    {
        app.UseSwagger(options => options.RouteTemplate = "swagger/{documentName}/swagger.json");

        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint($"/swagger/{DocumentName}/swagger.json", "IBS Backend Service v1");
            options.RoutePrefix = "swagger";
            options.DocumentTitle = "IBS Backend Service - API";
            options.DocExpansion(DocExpansion.List);
            options.DefaultModelsExpandDepth(1);
            options.DisplayRequestDuration();
            options.EnableTryItOutByDefault();
            // Keeps the pasted bearer token across a page reload while exploring.
            options.EnablePersistAuthorization();
        });

        return app;
    }

}
