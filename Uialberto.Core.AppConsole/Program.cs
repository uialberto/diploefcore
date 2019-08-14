using Microsoft.EntityFrameworkCore;
using System;
using Uialberto.Northwind.DataAccess;
using Uialberto.Northwind.Entities;

namespace Uialberto.Core.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            var optionBuilder = new DbContextOptionsBuilder<AppCoreContext>();

            optionBuilder.UseSqlServer("Server=.\\odin;Database=CoreNorthwind;Trusted_Connection=False;User Id=desa;Password=desa",
                            options => options.CommandTimeout(60))
                         .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            using (var context = new AppCoreContext(optionBuilder.Options))
            {
                Console.WriteLine("Introduce el nombre de gategoras");
                var category = Console.ReadLine();
                var newCategory = new Category
                {
                    CategoryName = category
                };
                context.Categories.Add(newCategory);
                var rowAffected = context.SaveChanges();
                Console.WriteLine($"Número de registros afectados {rowAffected}");
                Console.WriteLine("Categorias:");
                foreach (var entity in context.Categories)
                {
                    Console.WriteLine($"{entity.CategoryID}, {entity.CategoryName}");
                }

                Console.ReadLine();

            }
        }
    }
}
