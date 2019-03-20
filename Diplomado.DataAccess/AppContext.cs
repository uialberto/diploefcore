using System;
using System.Collections.Generic;
using System.Text;
using Diplomado.Entities;
using Microsoft.EntityFrameworkCore;

namespace Diplomado.DataAccess
{
    public class AppContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=True;"
            );
        }
    }
}
