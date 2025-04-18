using DotNetTemplate.Infrastructure.Options;

namespace DotNetTemplate.WebApi.DependencyInjection
{
    public static class OptionsConfigurationServiceRegistration
    {
        public static IServiceCollection AddConfigureAppOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseOptions>(configuration.GetSection("ConnectionStrings"));
            services.Configure<JwtSettingsOptions>(configuration.GetSection("JwtSettings"));

            return services;
        }
    }
}
