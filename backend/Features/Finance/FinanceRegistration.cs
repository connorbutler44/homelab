using Microsoft.Extensions.DependencyInjection;

namespace Homelab.Features.Finance;

public static class FinanceRegistration
{
    public static IServiceCollection AddFinanceFeature(this IServiceCollection services)
    {
        return services;
    }
}