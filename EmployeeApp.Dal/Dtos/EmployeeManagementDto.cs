namespace EmployeeApp.Dal.Dtos;

public class EmployeeManagementDto : UpdateEmployeeDto
{
    public string CompanyName { get; set; }
    public string ManagerFirstName { get; set; }
    public string ManagerLastName { get; set; }
}
