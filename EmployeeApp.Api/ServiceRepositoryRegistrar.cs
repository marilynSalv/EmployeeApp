using EmployeeApp.Api.Services;
using EmployeeApp.Business.Services;
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
            services.AddScoped<ISprocRepository, SprocRepository>();
            services.AddScoped<IScoped, ScopeService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IEmployeeManagementService, EmployeeManagementService>();
            services.AddScoped<IRefreshTokenGenerator, RefreshTokenGenerator>();
            services.AddScoped<IManagerSearchService, ManagerSearchService>(); //scoped One instance of a resource, but only for the current request. New request (i.e. hit an API endpoint again) = new instance

            // Services
            services.AddSingleton<ISingleton, ScopeService>(); //singleton One instance of a resource, reused anytime it's requested
            services.AddTransient<ITransient, ScopeService>(); //transient different instance of a resource, everytime it's requested
        }
    }
}
