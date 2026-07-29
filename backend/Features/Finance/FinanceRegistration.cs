using Homelab.Features.Finance.Importer;
using Homelab.Features.Finance.Importer.Providers.Amex;
using Homelab.Features.Finance.Importer.Providers.Chase;
using Homelab.Features.Finance.Importer.Providers.Ncsecu;
using Microsoft.Extensions.DependencyInjection;

namespace Homelab.Features.Finance;

public static class FinanceRegistration
{
    public static IServiceCollection AddFinanceFeature(this IServiceCollection services)
    {
        services.AddScoped<ITransactionImporter, TransactionImporter>();
        services.AddScoped<ICsvParser, AmexCsvParser>();
        services.AddScoped<ICsvParser, ChaseCsvParser>();
        services.AddScoped<ICsvParser, NcsecuCsvParser>();

        return services;
    }
}