
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace SBAPI.Infraestructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(
        this IServiceCollection services, 
        ConfigurationManager configuration)
    {
        //services.AddScoped<IAuthenticationService, AuthenticationService>();
        //services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
  
       // services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}