using EmployeeApp.Domain.DomainEntities;
using EmployeeApp.Domain.Interfaces.Repositories;

namespace EmployeeApp.Application.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;
    public CompanyService(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public Task<List<Company>> Search(string searchValue)
    {
        return _companyRepository.Search(searchValue);
    }
}
