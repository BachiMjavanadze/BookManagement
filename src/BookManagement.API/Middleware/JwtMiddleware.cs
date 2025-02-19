using BookManagement.API.Models;
using BookManagement.Core.Interfaces;
using BookManagement.Core.Settings;
using BookManagement.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace BookManagement.API.Middleware;

public static class JwtMiddleware
{
    public static IServiceCollection AddJwtServices(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettingsSection = configuration.GetSection("JwtSettings");
        services.Configure<JwtSettings>(jwtSettingsSection);
        var jwtSettings = jwtSettingsSection.Get<JwtSettings>()!;

        var key = Encoding.UTF8.GetBytes(jwtSettings.Secret);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidateAudience = true,
                ValidAudience = jwtSettings.Audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            options.Events = new JwtBearerEvents
            {
                OnChallenge = async context =>
                {
                    context.HandleResponse();

                    context.Response.StatusCode = 401;
                    context.Response.ContentType = "application/json";

                    var errorDetails = new ErrorDetails
                    {
                        StatusCode = 401,
                        Message = "Unauthorized access. Please login or provide valid token."
                    };

                    await context.Response.WriteAsJsonAsync(errorDetails);
                }
            };
        });

        return services;
    }
}