using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EmployeeApp.Data;

namespace EmployeeApp.Controllers
{
    [ApiController]
    [Route("employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public List<Employee> Get()
        {
            var result = _employeeRepository.Get();
            return result;
        }

        [HttpPut]
        public int Update(Employee dto)
        {
            var result = _employeeRepository.Update(dto.Id, dto.FirstName);
            return result;
        }
    }
}
