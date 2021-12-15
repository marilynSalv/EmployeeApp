using EmployeeApp.Api.Services;
using EmployeeApp.Dal.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeApp.Api
{
    public static class ServiceRepositoryRegistrar
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

            services.AddSingleton<ISingleton, ScopeService>();
            services.AddTransient<ITransient, ScopeService>();
            services.AddScoped<IScoped, ScopeService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<IRefreshTokenGenerator, RefreshTokenGenerator>();
        }
    }
}
