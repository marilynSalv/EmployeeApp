using EmployeeApp.Domain.DomainEntities;
namespace EmployeeApp.Domain.Interfaces.Repositories;

public interface ICompanyRepository
{
    Task<List<Company>> Search(string searchValue);
}