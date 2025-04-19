using DotNetTemplate.Infrastructure.Options;

namespace DotNetTemplate.WebApi.DependencyInjection
{
    public static class OptionsConfigurationServiceRegistration
    {
        public static IServiceCollection AddConfigureAppOptions(this IServiceCollection services, IConfiguration configuration)
        {
            _ = services.Configure<DatabaseOptions>(configuration.GetSection(nameof(DatabaseOptions)));
            _ = services.Configure<JwtSettingsOptions>(configuration.GetSection(nameof(JwtSettingsOptions)));

            return services;
        }
    }
}
