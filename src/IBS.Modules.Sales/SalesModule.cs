using IBS.Modules.Sales.Application.Options;
using IBS.Modules.Sales.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IBS.Modules.Sales;

/// <summary>The Sales module (spec sections 3 and 8). Currently just Lead management.</summary>
public static class SalesModule
{
    public static IServiceCollection AddSalesModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<SalesOptions>().Bind(configuration.GetSection(SalesOptions.SectionName));

        // QuestPDF refuses to render until a licence is declared. Community is the correct tier
        // for a studio of this size; it has to be set once, before the first document is built.
        QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
        services.AddScoped<ILeadService, LeadService>();
        services.AddScoped<IQuotationPricingService, QuotationPricingService>();
        services.AddScoped<IQuotationService, QuotationService>();
        services.AddScoped<IQuotationDeliveryService, QuotationDeliveryService>();
        return services;
    }
}
