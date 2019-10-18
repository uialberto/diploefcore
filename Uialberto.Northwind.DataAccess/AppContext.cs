using Microsoft.EntityFrameworkCore;
using System;
using Uialberto.Northwind.Entities;

namespace Uialberto.Northwind.DataAccess
{
    public class AppContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Server=localhost;Database=aspnet-MVCAuthSQL;Trusted_Connection=False;MultipleActiveResultSets=true;User Id=SA;Password=my-secret-password;

            optionsBuilder.UseSqlServer("Server=.\\odin;Database=MFCoreMod3;Trusted_Connection=False;User Id=desa;Password=desa");

            //optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["AppContext"].ConnectionString); //SystemConfiguration

            //var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false).Build();

            //optionsBuilder.UseSqlServer(config.GetConnectionString("AppContext")); //SystemConfiguration

            //optionsBuilder.UseSqlServer(
            //    "Server=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=True;"
            //);
        }
    }
}
