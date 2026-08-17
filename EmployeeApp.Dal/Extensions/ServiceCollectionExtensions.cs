using EmployeeApp.Application.Interfaces.Services;
using EmployeeApp.Application.Services;
using EmployeeApp.Domain.Interfaces.Repositories;
using EmployeeApp.Infrastructure.Contexts;
using EmployeeApp.Infrastructure.Entities;
using EmployeeApp.Infrastructure.Identity;
using EmployeeApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace EmployeeApp.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection SetupIdentityContext(this IServiceCollection services, string connectionString, string jwtSecret)
    {
        services.AddDbContextPool<PlayGroundContext>(options =>
        { 
            options.UseNpgsql(connectionString);
            options.UseSnakeCaseNamingConvention();
        });

        services.AddIdentityCore<ApplicationUser>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 7;
            options.Password.RequireUppercase = true;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
            options.Lockout.MaxFailedAccessAttempts = 3;
        })
        .AddRoles<IdentityRole<Guid>>()
        .AddEntityFrameworkStores<PlayGroundContext>()
        .AddDefaultTokenProviders()
        .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultAuthenticatorProvider);

        services.AddAuthentication(auth =>
        {
            auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                RequireExpirationTime = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSecret))
            };
        });

        return services;
    }

    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeManagementRepository, EmployeeManagementRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
        services.AddScoped<IManagerSearchRepository, ManagerSearchRepository>();
        services.AddScoped<IRefreshTokenGenerator, RefreshTokenGenerator>();
        services.AddScoped<IAuthenticationService, IdentityAuthenticationService>();

        return services;
    }
}
