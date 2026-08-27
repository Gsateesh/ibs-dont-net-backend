using IBS.Infrastructure.Auditing;
using IBS.Infrastructure.Directories;
using IBS.Infrastructure.Email;
using IBS.Infrastructure.Persistence;
using IBS.Infrastructure.Security;
using IBS.Infrastructure.Storage;
using IBS.Modules.Sales.Application.Abstractions;
using IBS.Modules.UsersAccess.Application.Abstractions;
using IBS.SharedKernel.Auditing;
using IBS.SharedKernel.Directories;
using IBS.SharedKernel.Time;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IBS.Infrastructure;

/// <summary>
/// Wires the database, email, storage, hashing and auditing implementations. Every module
/// depends on the interfaces registered here and on none of the concrete types.
/// </summary>
public static class InfrastructureRegistration
{
    /// <summary>Registers infrastructure for the API host and for the seed tool alike.</summary>
    public static IServiceCollection AddIbsInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("IbsDatabase");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            var found = Configuration.LocalSettings.Find();

            throw new InvalidOperationException(
                $"Connection string 'IbsDatabase' is missing. Set ConnectionStrings:IbsDatabase in " +
                $"{Configuration.LocalSettings.FileName} at the repository root. " +
                (found is null
                    ? $"No {Configuration.LocalSettings.FileName} was found from {AppContext.BaseDirectory}."
                    : $"The file was read from {found}, but it has no such value.") +
                " (In Azure this value comes from Key Vault instead.)");
        }

        services.AddDbContext<IbsDbContext>(options =>
            options.UseSqlServer(connectionString, sql =>
            {
                sql.MigrationsAssembly(typeof(IbsDbContext).Assembly.FullName);
                sql.EnableRetryOnFailure();
            }));

        // The module talks to its own slice of the context, never to the concrete type.
        services.AddScoped<IUsersAccessDbContext>(sp => sp.GetRequiredService<IbsDbContext>());
        services.AddScoped<ISalesDbContext>(sp => sp.GetRequiredService<IbsDbContext>());

        services.AddSingleton<IClock, SystemClock>();
        services.AddSingleton<IPasswordHasher, IdentityPasswordHasher>();
        services.AddSingleton<ITokenGenerator, ActivationTokenGenerator>();
        services.AddScoped<IAuditLogWriter, AuditLogWriter>();
        services.AddScoped<IAuditLogReader, AuditLogReader>();
        services.AddScoped<IEmployeeDirectory, EmployeeDirectory>();

        services.AddOptions<EmailOptions>().Bind(configuration.GetSection(EmailOptions.SectionName));
        services.AddOptions<StorageOptions>().Bind(configuration.GetSection(StorageOptions.SectionName));

        var email = configuration.GetSection(EmailOptions.SectionName).Get<EmailOptions>() ?? new EmailOptions();
        var storage = configuration.GetSection(StorageOptions.SectionName).Get<StorageOptions>() ?? new StorageOptions();

        // Real Azure clients when configured; otherwise the local stand-ins, so a developer
        // machine needs no Azure resources to walk the invite and upload flows.
        if (email.IsConfigured)
        {
            services.AddSingleton<IEmailSender, AcsEmailSender>();
        }
        else
        {
            services.AddSingleton<IEmailSender, LoggingEmailSender>();
        }

        if (storage.IsConfigured)
        {
            services.AddSingleton<IFileStorage, BlobFileStorage>();
        }
        else
        {
            services.AddSingleton<IFileStorage, LocalFileStorage>();
        }

        return services;
    }
}
