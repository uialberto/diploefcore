
using System;

namespace Diplo.Cliente.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new NorthwindContext())
            {
                Console.WriteLine("Ingres nombre de categoria:");
                var categoryName = Console.ReadLine();

                var newCategory = new Categories()
                {
                    CategoryName = categoryName
                };
                context.Categories.Add(newCategory);
                var result = context.SaveChanges();
                Console.WriteLine($"{result} registro guardado en la BD.");
                Console.WriteLine("Categorias:");
                foreach (var item in context.Categories)
                {

                    Console.WriteLine($"{item.CategoryId} {item.CategoryName}");
                }

            }
        }
    }
}
