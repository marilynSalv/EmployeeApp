using EmployeeApp.Api.Services;
using EmployeeApp.Dal.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApp.Api.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("ManagerSearch")]
    public class ManagerSearchController : ControllerBase
    {
        private readonly IManagerSearchService _managerSearchService;

        public ManagerSearchController(IManagerSearchService managerSearchService)
        {
            _managerSearchService = managerSearchService;
        }

        [HttpPost]
        public async Task<ActionResult<List<ManagerSearchDto>>> PostManagerSearch([FromBody] string searchValue)
        {
            var results = await _managerSearchService.ManagerSearch(searchValue);
            return results;
        }

    }
}
