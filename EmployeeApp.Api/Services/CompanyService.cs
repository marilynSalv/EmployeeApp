using EmployeeApp.Dal.Dtos;
using EmployeeApp.Dal.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApp.Api.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public Task<List<CompanySearchDto>> Search(string searchValue)
        {
            return _companyRepository.Search(searchValue);
        }
    }
}
