using EmployeeApp.Dal.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EmployeeApp.Dal.Repositories;

public class SprocRepository : ISprocRepository
{
    private readonly PlayGroundContext _context;
    public SprocRepository(PlayGroundContext context)
    {
        _context = context;
    }


    public async Task ReadSprocTest()
    {
        var lastName = new SqlParameter("lastName", "test");
        var firstName = new SqlParameter("firstName", "test");
        var x = _context.Database.GetCommandTimeout();
        _context.Database.SetCommandTimeout(90);

        var results = await _context.TestSprocDtos
            .FromSql($"EXECUTE dbo.TestFirstSproc @LastName={lastName}, @FirstName={firstName}")
            .ToListAsync();

       var test = results;
    }
}
