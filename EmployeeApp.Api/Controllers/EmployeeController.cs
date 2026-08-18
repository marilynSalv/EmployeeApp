using EmployeeApp.Application.Services;
using EmployeeApp.Domain.DomainEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApp.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManagementService _employeeManagementService;

        public EmployeeController(IEmployeeManagementService employeeManagementService)
        {
            _employeeManagementService = employeeManagementService;  
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            var result = await _employeeManagementService.GetEmployees();
            return result;
        }

        [HttpPut]
        public async Task<Guid> Update([FromBody] Employee dto)
        {
            var result = await _employeeManagementService.UpdateEmployee(dto);
            return result;
        }
    }
}
