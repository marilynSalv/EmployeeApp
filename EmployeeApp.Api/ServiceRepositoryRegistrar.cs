using EmployeeApp.Api.Services;
using EmployeeApp.Dal.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeApp.Api
{
    public static class ServiceRepositoryRegistrar
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // Repositories 
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

            // Services
            services.AddSingleton<ISingleton, ScopeService>();
            services.AddTransient<ITransient, ScopeService>();
            services.AddScoped<IScoped, ScopeService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IRefreshTokenGenerator, RefreshTokenGenerator>();
        }
    }
}
