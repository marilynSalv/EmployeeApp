using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Dal.Dtos;

public class EmployeeManagementDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string ZipCode { get; set; }
    public int? CompanyId { get; set; }
    public int? ManagerId { get; set; }
    public bool IsManager { get; set; }
}
