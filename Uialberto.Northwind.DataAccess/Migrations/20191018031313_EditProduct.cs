using Microsoft.EntityFrameworkCore.Migrations;

namespace Uialberto.Northwind.DataAccess.Migrations
{
    public partial class EditProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Producto",
                table: "Products",
                newName: "ProductoTitle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductoTitle",
                table: "Products",
                newName: "Producto");
        }
    }
}
