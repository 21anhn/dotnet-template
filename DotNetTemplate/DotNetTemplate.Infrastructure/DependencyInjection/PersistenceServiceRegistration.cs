using DotNetTemplate.Infrastructure.Options;
using DotNetTemplate.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetTemplate.WebApi.DependencyInjection
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, DatabaseOptions databaseOptions)
        {
            _ = services.AddDbContext<AppDbContext>(options => options.UseNpgsql(databaseOptions.ConnectionStrings));

            return services;
        }
    }
}
