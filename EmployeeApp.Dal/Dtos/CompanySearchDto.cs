using System;

namespace EmployeeApp.Dal.Dtos;
public class CompanySearchDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Industry { get; set; }
}
