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
            services.AddScoped<IEmployeeManagementRepository, EmployeeManagementRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IManagerSearchRepository, ManagerSearchRepository>();

            // Services
            services.AddSingleton<ISingleton, ScopeService>();
            services.AddTransient<ITransient, ScopeService>();
            services.AddScoped<IScoped, ScopeService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IRefreshTokenGenerator, RefreshTokenGenerator>();
            services.AddScoped<IManagerSearchService, ManagerSearchService>();
        }
    }
}
