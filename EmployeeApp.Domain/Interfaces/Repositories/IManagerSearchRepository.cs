using EmployeeApp.Domain.ValueObjects;

namespace EmployeeApp.Domain.Interfaces.Repositories;

public interface IManagerSearchRepository
{
    Task<List<ManagerSearch>> ManagerSearch(string searchValue);
}