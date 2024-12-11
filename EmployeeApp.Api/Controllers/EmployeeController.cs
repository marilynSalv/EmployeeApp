using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EmployeeApp.Dal.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using EmployeeApp.Dal.Dtos;
using EmployeeApp.Business.Services;

namespace EmployeeApp.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManagementService _employeeManagementService;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmployeeController(IEmployeeManagementService employeeManagementService,
            UserManager<ApplicationUser> userManager)
        {
            _employeeManagementService = employeeManagementService;  
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeManagementDto>>> Get()
        {
            var result = await _employeeManagementService.GetEmployees();
            return result;
        }

        [HttpPut]
        public async Task<int> Update([FromBody] UpdateEmployeeDto dto)
        {
            var result = await _employeeManagementService.UpdateEmployee(dto);
            return result;
        }
    }
}
