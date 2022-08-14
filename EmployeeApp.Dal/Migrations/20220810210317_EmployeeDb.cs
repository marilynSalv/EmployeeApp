using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeApp.Dal.Migrations
{
    public partial class EmployeeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Market",
                schema: "dbo",
                table: "Company");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Market",
                schema: "dbo",
                table: "Company",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: true);
        }
    }
}
