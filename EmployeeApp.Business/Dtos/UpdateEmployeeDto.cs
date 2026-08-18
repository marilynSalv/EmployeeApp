using System;

namespace EmployeeApp.Application.Dtos;

public class UpdateEmployeeDto : EmployeeDto
{
    public Guid Id { get; set; }
}
