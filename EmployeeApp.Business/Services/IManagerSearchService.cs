using EmployeeApp.Application.Dtos;
using EmployeeApp.Domain.ValueObjects;

namespace EmployeeApp.Application.Services;
public interface IManagerSearchService
{
    Task<List<ManagerSearch>> ManagerSearch(string searchValue);
}