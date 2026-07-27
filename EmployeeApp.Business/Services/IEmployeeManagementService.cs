using EmployeeApp.Domain.DomainEntities;

namespace EmployeeApp.Application.Services;

public interface IEmployeeManagementService
{
    Task<List<Employee>> GetEmployees();
    Task<Guid> UpdateEmployee(Employee dto);
}