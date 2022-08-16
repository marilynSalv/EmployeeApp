using EmployeeApp.Dal.Dtos;
using EmployeeApp.Dal.Repositories;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IManagerSearchRepository _managerSearchRepository;

        public ManagerSearchController(IManagerSearchRepository managerSearchRepository)
        {
            _managerSearchRepository = managerSearchRepository;
        }

        [HttpPost]
        public async Task<ActionResult<List<ManagerSearchDto>>> PostManagerSearch([FromBody] string searchValue)
        {
            var results = await _managerSearchRepository.ManagerSearch(searchValue);
            return results;
        }

    }
}
