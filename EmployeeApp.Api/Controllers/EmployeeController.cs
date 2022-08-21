using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EmployeeApp.Dal.Entities;
using EmployeeApp.Dal.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using EmployeeApp.Dal.Dtos;

namespace EmployeeApp.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManagementRepository _employeeRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmployeeController(IEmployeeManagementRepository employeeRepository,
            UserManager<ApplicationUser> userManager)
        {
            _employeeRepository = employeeRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeManagementDto>>> Get()
        {
            //var userId = User.Claims.First(x => x.Type == "UserID").Value;
            //var user = await _userManager.FindByIdAsync(userId);
            var result = await _employeeRepository.Get();
            return result;
        }

        [HttpPut]
        public int Update([FromBody] EmployeeManagementDto dto)
        {
            var result = _employeeRepository.Update(dto.Id, dto.FirstName);
            return result;
        }
    }
}
