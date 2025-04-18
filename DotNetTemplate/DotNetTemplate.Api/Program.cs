using DotNetTemplate.Infrastructure.Options;
using DotNetTemplate.Infrastructure.Persistence;
using DotNetTemplate.WebApi.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DotNetTemplate.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddConfigureAppOptions(builder.Configuration);

            var jwtOptions = builder.Configuration.GetSection("JwtSettings").Get<JwtSettingsOptions>();
            builder.Services.AddCustomJwtAuthentication(jwtOptions);

            // Add services to the container.
            _ = builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration["ConnectionStrings:AppDbContext"]));

            _ = builder.Services.AddControllers();
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
