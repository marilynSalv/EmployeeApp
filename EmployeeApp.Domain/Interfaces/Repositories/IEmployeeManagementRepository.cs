using EmployeeApp.Domain.DomainEntities;

namespace EmployeeApp.Domain.Interfaces.Repositories;

public interface IEmployeeManagementRepository
{
    Task<List<Employee>> Get();
    Task<Guid> Update(Employee employeeDto);
}
