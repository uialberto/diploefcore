﻿using System;
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

        private string _dbPath = ""; /*CloudNorthWindLite.db*/

        public AppContext() : this("CloudNorthWindLite.db") { }
        public AppContext(string dbPath)
        {
            this._dbPath = dbPath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_dbPath}");
        }
    }
}