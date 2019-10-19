using Microsoft.EntityFrameworkCore.Migrations;

namespace Uialberto.Northwind.DataAccess.Migrations
{
    public partial class CreateView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateViewCategoriesProducts();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropViewCategoriesProducts();
        }
    }
}
