using EmployeeApp.Dal.Contexts;
using EmployeeApp.Dal.Dtos;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmployeeApp.Dal.Repositories;

public class SprocRepository : ISprocRepository
{
    private readonly PlayGroundContext _context;
    public SprocRepository(PlayGroundContext context)
    {
        _context = context;
    }


    public void ReadSprocTest()
    {
        var results = new List<TestSprocDto>();

        using SqlConnection connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=PlayGround;Trusted_Connection=True;MultipleActiveResultSets=true");
        SqlCommand command = new SqlCommand("dbo.TestFirstSproc", connection);
        command.CommandType = CommandType.StoredProcedure;
        //command.CommandTimeout = 1;

        command.Parameters.AddWithValue("@FirstName", "Test");
        command.Parameters.AddWithValue("@LastName", "Admin");

        command.Connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            results.Add(new TestSprocDto()
            {
                Id = (int)reader[0],
                FirstName = (string)reader[1],
                LastName = (string)reader[2],
                Username = (string)reader[3]
            });
        }
        reader.Close();

        var test = results;
    }
}
