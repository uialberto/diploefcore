using System;
using System.Collections.Generic;
using System.Text;
using Cloud.Northwind.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cloud.Northwind.DataAccess
{
    public class AppContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Server=localhost;Database=aspnet-MVCAuthSQL;Trusted_Connection=False;MultipleActiveResultSets=true;User Id=SA;Password=my-secret-password;

            //optionsBuilder.UseSqlServer("Server=.\\odin;Database=CoreNorthwind;Trusted_Connection=False;User Id=desa;Password=desa");

            optionsBuilder.UseSqlite("Data Source=CloudNorthWindLite.db");

            //optionsBuilder.UseSqlServer(
            //    "Server=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=True;"
            //);
        }
    }
}
