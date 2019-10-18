using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System;
using Uialberto.Northwind.Entities;

namespace Uialberto.Core.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Northwind.DataAccess.AppContext())
            {

                ////context.Database.Migrate(); // CASO 1


                // CASO 2
                ////Console.WriteLine("Aplicando Migraciones Database");
                //var migrator = context.Database.GetInfrastructure()
                //    .GetService<IMigrator>();

                //migrator.Migrate();
                //Console.ReadLine();

                // CASO 3, No Usar si se va trabajar con migraciones
                context.Database.EnsureCreated();   


            }
        }
    }
}
