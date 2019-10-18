using Microsoft.EntityFrameworkCore.Migrations;

namespace Uialberto.Northwind.DataAccess.Migrations
{
    public partial class AddTelefono : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Categories");
        }
    }
}
