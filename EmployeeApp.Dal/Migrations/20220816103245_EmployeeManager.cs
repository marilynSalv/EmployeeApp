using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeApp.Dal.Migrations
{
    public partial class EmployeeManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsManager",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CompanyId",
                table: "Employee",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ManagerId",
                table: "Employee",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Company_CompanyId",
                table: "Employee",
                column: "CompanyId",
                principalSchema: "dbo",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Employee_ManagerId",
                table: "Employee",
                column: "ManagerId",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Company_CompanyId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Employee_ManagerId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_CompanyId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_ManagerId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "IsManager",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Employee");
        }
    }
}
