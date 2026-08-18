using System;

namespace EmployeeApp.Application.Dtos;
public class CompanySearchDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Industry { get; set; }
}
