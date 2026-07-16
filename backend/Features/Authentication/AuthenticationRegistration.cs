using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Homelab.Features.Authentication;

public static class AuthenticationRegistration
{
    public static IServiceCollection AddAuthenticationFeature(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<AuthenticationOptions>(
            configuration.GetSection("Authentication"));

        services.AddSingleton<AuthenticationService>();

        return services;
    }
}