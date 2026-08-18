using EmployeeApp.Application.Services;
using EmployeeApp.Domain.DomainEntities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApp.Api.Controllers
{
    [ApiController]
    [Route("Company")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("Search")]
        public async Task<ActionResult<List<Company>>> SearchCompanies([FromBody] string searchValue)
        {
            var results = await _companyService.Search(searchValue);
            return results;
        }
    }
}
