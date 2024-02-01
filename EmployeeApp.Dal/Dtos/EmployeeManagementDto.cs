using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Dal.Dtos;

public class EmployeeManagementDto : UpdateEmployeeDto
{
    public string CompanyName { get; set; }
    public string ManagerFirstName { get; set; }
    public string ManagerLastName { get; set; }
}
