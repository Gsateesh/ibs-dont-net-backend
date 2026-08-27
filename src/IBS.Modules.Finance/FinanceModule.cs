using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IBS.Modules.Finance;

/// <summary>
/// Placeholder for the Finance module (spec sections 3 and 8). The folder and registration hook
/// exist from day one so the boundary is real before any code lands here; nothing is built yet.
/// </summary>
public static class FinanceModule
{
    /// <summary>No-op until the module is built. Called from the API host alongside the others.</summary>
    public static IServiceCollection AddFinanceModule(this IServiceCollection services, IConfiguration configuration)
    {
        _ = configuration;
        return services;
    }
}
