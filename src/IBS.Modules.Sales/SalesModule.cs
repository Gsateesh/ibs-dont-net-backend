using IBS.Modules.Sales.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IBS.Modules.Sales;

/// <summary>The Sales module (spec sections 3 and 8). Currently just Lead management.</summary>
public static class SalesModule
{
    public static IServiceCollection AddSalesModule(this IServiceCollection services, IConfiguration configuration)
    {
        _ = configuration;
        services.AddScoped<ILeadService, LeadService>();
        return services;
    }
}
