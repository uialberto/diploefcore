using Microsoft.EntityFrameworkCore.Migrations;

namespace Uialberto.Northwind.DataAccess.Migrations
{
    public partial class ColumEmployeeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Employees",
                nullable:true
                );

            migrationBuilder.Sql(
                @"update Employees set Name= FirstName + ' ' + LastName"
                );

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employees",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employees",
                nullable: true);
        }
    }
}
