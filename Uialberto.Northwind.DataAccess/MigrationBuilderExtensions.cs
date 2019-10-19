using Microsoft.EntityFrameworkCore.Migrations;

namespace Uialberto.Northwind.DataAccess
{
    public static class MigrationBuilderExtensions
    {
        public static MigrationBuilder CreateUser(this MigrationBuilder builder, string username, string password)
        {
            switch (builder.ActiveProvider)
            {
                case "Npgsql.EntityFrameworkCore.PostgreSQL":
                    {
                        builder.Sql($"create user {username} with password '{password}';");
                    }
                    break;
                case "Microsoft.EntityFrameworkCore.SqlServer":
                    {
                        builder.Sql($"create user {username} with password '{password}';");
                    }
                    break;
                default:
                    builder.Sql($"create user {username} with password '{password}';");
                    break;
            }


            return builder;
        }

        public static MigrationBuilder CreateViewCategoriesProducts(this MigrationBuilder builder)
        {
            var query = string.Empty;
            query += "  create view v_CategoriasProductos as  ";
            query += "  select	c.CategoryID,c.CategoryName,  ";
            query += "  		p.ProductID, p.NombreProducto  ";
            query += "  from Categories c  ";
            query += "  	INNER JOIN Products p on c.CategoryID = p.CategoryID;  ";

            builder.Sql(query);

            return builder;
        }

        public static MigrationBuilder DropViewCategoriesProducts(this MigrationBuilder builder)
        {
            var query = string.Empty;
            query += "  drop view v_CategoriasProductos";

            builder.Sql(query);

            return builder;
        }
    }
}
