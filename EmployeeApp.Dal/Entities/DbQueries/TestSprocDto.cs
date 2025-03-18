using Microsoft.EntityFrameworkCore;
using System;
namespace EmployeeApp.Dal.Entities.DbQueries;

[Keyless]
public class TestSprocDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
}
