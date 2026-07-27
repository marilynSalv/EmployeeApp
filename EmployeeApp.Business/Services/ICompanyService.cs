using EmployeeApp.Domain.DomainEntities;

namespace EmployeeApp.Application.Services;
public interface ICompanyService
{
    Task<List<Company>> Search(string searchValue);
}