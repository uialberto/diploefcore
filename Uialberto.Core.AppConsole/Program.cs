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

            //var optionBuilder = new DbContextOptionsBuilder<AppCoreContext>();

            //optionBuilder.UseSqlServer("Server=.\\odin;Database=CoreNorthwind;Trusted_Connection=False;User Id=desa;Password=desa",
            //                options => options.CommandTimeout(60))
            //             .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            using (var context = new AppCoreContext())
            {
                Console.WriteLine("Introduce el nombre del Empleado");
                var employee = new Employee { CompanyID = 1, EmployeeNumber = "90000", FirstName = "Luis Alberto", LastName= "Baigorria Rodas"};
                var employee2 = new Employee { CompanyID = 2, EmployeeNumber = "90001", FirstName = "Carlos Alberto", LastName = "Rodas" };
                var employee3 = new Employee { CompanyID = 3, EmployeeNumber = "90002", FirstName = "Alberto", LastName = "Sample" };
                context.Employees.AddRange(employee, employee2,employee3);
                context.SaveChanges();
                Console.WriteLine($"{employee.CodeSequence}, {employee2.CodeSequence}, {employee3.CodeSequence}");

                Console.ReadLine();

            }
        }
    }
}
