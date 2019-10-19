using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Uialberto.Northwind.DataAccess
{
    public class AppContextMigrationSqlGenerator : SqlServerMigrationsSqlGenerator
    {
        public AppContextMigrationSqlGenerator(MigrationsSqlGeneratorDependencies dependencies
            , IMigrationsAnnotationProvider provider):base(dependencies,provider)
        {

        }

        protected override void Generate(MigrationOperation operation, 
            IModel model, 
            MigrationCommandListBuilder builder)
        {
            if (operation is CreateCategoryProductsView createView)
            {
                GenerateCreateView(createView, builder);
            }
            else if (operation is DropView dropView)
            {
                GenerateDropView(dropView, builder);
            }
            else
            {
                base.Generate(operation, model, builder);
            }

        }

        private void GenerateDropView(DropView dropView, MigrationCommandListBuilder builder)
        {
            var query = $"  drop view {dropView.ViewName}";
            builder.AppendLine(query);
            builder.EndCommand();
        }

        private void GenerateCreateView(CreateCategoryProductsView createView, MigrationCommandListBuilder builder)
        {
            var query = string.Empty;
            query += "  create view v_CategoriasProductos as  ";
            query += "  select	c.CategoryID,c.CategoryName,  ";
            query += "  		p.ProductID, p.Producto  ";
            query += "  from Categories c  ";
            query += "  	INNER JOIN Products p on c.CategoryID = p.CategoryID;  ";

            builder.Append(query);
            builder.EndCommand();

        }
    }
}
