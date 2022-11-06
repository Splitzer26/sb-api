
using Microsoft.Extensions.DependencyInjection;
using SBAPI.Application.Common.Interfaces.Authentication;
using SBAPI.Application.Common.Interfaces.Service;
using SBAPI.Application.Services.Auth.Authentication;
using SBAPI.Infraestructure.Authentication;
using SBAPI.Infraestructure.Services;
using Microsoft.Extensions.Configuration;
using SBAPI.Application.Common.Interfaces.Persistence;
using SBAPI.Infraestructure.Persistence;

namespace SBAPI.Infraestructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(
        this IServiceCollection services, 
        ConfigurationManager configuration)
    {
        //services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}