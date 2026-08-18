using System;

namespace EmployeeApp.Application.Dtos
{
    public class ManagerSearchDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
    }
}
