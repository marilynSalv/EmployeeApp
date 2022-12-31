using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Dal.Entities.DbQueries;

[Keyless]
public class TestSprocDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
}
