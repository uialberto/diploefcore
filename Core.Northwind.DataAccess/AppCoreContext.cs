using Core.Northwind.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Northwind.DataAccess
{
    public class AppCoreContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=.\\odin;Database=CoreNorthwindTest;Trusted_Connection=False;User Id=desa;Password=desa");
            var currentDirectory = Directory.GetCurrentDirectory();
            var config = new ConfigurationBuilder().SetBasePath(currentDirectory).AddJsonFile("appsettings.json", optional: false).Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("AppContext"));
        }
    }
}
