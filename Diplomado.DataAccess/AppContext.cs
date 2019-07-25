﻿using System;
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
            //Server=localhost;Database=aspnet-MVCAuthSQL;Trusted_Connection=False;MultipleActiveResultSets=true;User Id=SA;Password=my-secret-password;

            optionsBuilder.UseSqlServer("Server=.\\odin;Database=Northwind_Migra;Trusted_Connection=False;User Id=desa;Password=desa");

            //optionsBuilder.UseSqlServer(
            //    "Server=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=True;"
            //);
        }
    }
}