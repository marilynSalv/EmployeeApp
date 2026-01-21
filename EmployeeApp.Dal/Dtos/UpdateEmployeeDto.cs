using System;

namespace EmployeeApp.Dal.Dtos;

public class UpdateEmployeeDto : EmployeeDto
{
    public Guid Id { get; set; }
}
