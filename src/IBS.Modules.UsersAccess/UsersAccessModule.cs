using IBS.Modules.UsersAccess.Application.Options;
using IBS.Modules.UsersAccess.Application.Services;
using IBS.Modules.UsersAccess.Infrastructure;
using IBS.SharedKernel.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IBS.Modules.UsersAccess;

/// <summary>
/// Registration surface of the users and access module. The API host calls this one method
/// and knows nothing about the internals - which is what keeps the module boundary honest
/// as the other five modules land.
/// </summary>
public static class UsersAccessModule
{
    /// <summary>Registers the services, options and permission checker of this module.</summary>
    public static IServiceCollection AddUsersAccessModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<UsersAccessOptions>()
            .Bind(configuration.GetSection(UsersAccessOptions.SectionName))
            .ValidateOnStart();

        // The shared permission helper every module resolves.
        services.AddScoped<IPermissionChecker, PermissionChecker>();

        // Backs the JWT bearer "is this account still Active" check the API runs on every
        // authenticated request (see IAccountStatusChecker's doc for why this is separate).
        services.AddScoped<IAccountStatusChecker, AccountStatusChecker>();

        services.AddScoped<AuthService>();
        services.AddScoped<IAuthService>(sp => sp.GetRequiredService<AuthService>());
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<IStatutoryService, StatutoryService>();
        services.AddScoped<IDocumentService, DocumentService>();
        services.AddScoped<ISettingsService, SettingsService>();
        services.AddScoped<IAuditService, AuditService>();

        return services;
    }
}
