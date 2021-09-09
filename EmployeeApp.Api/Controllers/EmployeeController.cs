using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EmployeeApp.Dal.Entities;
using EmployeeApp.Dal.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeApp.Api.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            var result = _employeeRepository.Get();
            return result;
        }

        [HttpPut]
        public int Update([FromBody]Employee dto)
        {
            var result = _employeeRepository.Update(dto.Id, dto.FirstName);
            return result;
        }
    }
}
