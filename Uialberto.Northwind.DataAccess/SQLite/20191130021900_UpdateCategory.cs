using Microsoft.EntityFrameworkCore.Migrations;

namespace Uialberto.Northwind.DataAccess.SQLite
{
    public partial class UpdateCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Autorizador",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autorizador",
                table: "Categories");
        }
    }
}
