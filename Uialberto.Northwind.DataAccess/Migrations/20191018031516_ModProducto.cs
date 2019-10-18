using Microsoft.EntityFrameworkCore.Migrations;

namespace Uialberto.Northwind.DataAccess.Migrations
{
    public partial class ModProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Producto",
                table: "Products",
                newName: "DesProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DesProducto",
                table: "Products",
                newName: "Producto");
        }
    }
}
