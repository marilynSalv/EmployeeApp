namespace EmployeeApp.Domain.DomainEntities;

public class Employee
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string ZipCode { get; set; }

    public Guid? CompanyId { get; set; }
    public Guid? ManagerId { get; set; }
    public bool IsManager { get; set; }

    public string CompanyName { get; set; }
    public string ManagerFirstName { get; set; }
    public string ManagerLastName { get; set; }
}
