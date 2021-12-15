using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeApp.Dal.Migrations
{
    public partial class AddTokenExpiration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenCreatedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RefreshTokenValid",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshTokenCreatedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenValid",
                table: "AspNetUsers");
        }
    }
}
