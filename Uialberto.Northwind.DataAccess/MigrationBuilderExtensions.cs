using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

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
           
            builder.Operations.Add(new CreateCategoryProductsView());
            return builder;
        }

        public static MigrationBuilder DropViews(this MigrationBuilder builder, string viewName)
        {

            builder.Operations.Add(new DropView(viewName));
            return builder;
        }
    }

    public class CreateCategoryProductsView : MigrationOperation
    { 
        
    }

    public class DropView : MigrationOperation
    {
        public DropView(string viewName)
        {
            ViewName = viewName;
        }
        public string ViewName { get; set; }
    }
}
