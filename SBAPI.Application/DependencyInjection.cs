using Microsoft.Extensions.DependencyInjection;
using SBAPI.Application.Services.Auth.Authentication;

namespace SBAPI.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
       services.AddScoped<IAuthenticationService, AuthenticationService>();
       return services;
    }
}