using System.Text;
using DotNetTemplate.Infrastructure.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace DotNetTemplate.WebApi.DependencyInjection
{
    public static class AuthenticationServiceRegistration
    {
        public static IServiceCollection AddCustomJwtAuthentication(this IServiceCollection services, JwtSettingsOptions jwtSettingsOptions)
        {
            _ = services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var key = UTF8Encoding.UTF8.GetBytes(jwtSettingsOptions.SecretKey);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtSettingsOptions.Issuer,
                    ValidAudience = jwtSettingsOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                };
            });

            _ = services.AddAuthorization();

            return services;
        }
    }
}
