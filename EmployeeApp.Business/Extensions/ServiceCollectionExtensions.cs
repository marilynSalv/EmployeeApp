using EmployeeApp.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeApp.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IScoped, ScopeService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IEmployeeManagementService, EmployeeManagementService>();
        services.AddScoped<IManagerSearchService, ManagerSearchService>(); //scoped One instance of a resource, but only for the current request. New request (i.e. hit an API endpoint again) = new instance
        services.AddSingleton<ISingleton, ScopeService>(); //singleton One instance of a resource, reused anytime it's requested
        services.AddTransient<ITransient, ScopeService>(); //transient different instance of a resource, everytime it's requested

        return services;
    }
}
