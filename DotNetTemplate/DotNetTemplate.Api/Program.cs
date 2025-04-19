using DotNetTemplate.Infrastructure.Options;
using DotNetTemplate.WebApi.Common.ApiHandlers;
using DotNetTemplate.WebApi.DependencyInjection;

namespace DotNetTemplate.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            _ = builder.Services.AddConfigureAppOptions(builder.Configuration);

            var jwtOptions = builder.Configuration.GetSection(nameof(JwtSettingsOptions)).Get<JwtSettingsOptions>();
            _ = builder.Services.AddCustomJwtAuthentication(jwtOptions);

            var databaseOptions = builder.Configuration.GetSection(nameof(DatabaseOptions)).Get<DatabaseOptions>();
            _ = builder.Services.AddCustomDbContext(databaseOptions);

            _ = builder.Services.AddControllers(options =>
            {
                options.Conventions.Add(new PluralizeControllerRouteConvention());
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            _ = builder.Services.AddEndpointsApiExplorer();
            _ = builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                _ = app.UseSwagger();
                _ = app.UseSwaggerUI();
            }

            _ = app.UseHttpsRedirection();

            _ = app.UseAuthentication();

            _ = app.UseAuthorization();

            _ = app.MapControllers();

            app.Run();
        }
    }
}
