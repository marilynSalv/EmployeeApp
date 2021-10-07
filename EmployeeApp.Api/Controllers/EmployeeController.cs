using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EmployeeApp.Dal.Entities;
using EmployeeApp.Dal.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EmployeeApp.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmployeeController(IEmployeeRepository employeeRepository,
            UserManager<ApplicationUser> userManager)
        {
            _employeeRepository = employeeRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            //var userId = User.Claims.First(x => x.Type == "UserID").Value;
            //var user = await _userManager.FindByIdAsync(userId);
            var result = await _employeeRepository.Get();
            return result;
        }

        [HttpPut]
        public int Update([FromBody] Employee dto)
        {
            var result = _employeeRepository.Update(dto.Id, dto.FirstName);
            return result;
        }
    }
}
