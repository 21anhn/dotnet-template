using DotNetTemplate.Infrastructure.Options;

namespace DotNetTemplate.WebApi.DependencyInjection
{
    public static class WebApiServiceRegistration
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services, IConfiguration configuration)
        {
            _ = services.AddConfigureAppOptions(configuration);

            var jwtOptions = configuration.GetSection(nameof(JwtSettingsOptions)).Get<JwtSettingsOptions>();
            _ = services.AddCustomJwtAuthentication(jwtOptions);

            var databaseOptions = configuration.GetSection(nameof(DatabaseOptions)).Get<DatabaseOptions>();
            _ = services.AddCustomDbContext(databaseOptions);

            return services;
        }
    }
}
