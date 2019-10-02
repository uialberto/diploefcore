using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;
using Uialberto.Northwind.Entities;

namespace Uialberto.Northwind.DataAccess
{
    public class NorthwindContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Helpers.HelperConfiguration.GetAppConfiguration().ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);

            //Server=localhost;Database=aspnet-MVCAuthSQL;Trusted_Connection=False;MultipleActiveResultSets=true;User Id=SA;Password=my-secret-password;

            //optionsBuilder.UseSqlServer("Server=.\\odin;Database=CoreNorthwind;Trusted_Connection=False;User Id=desa;Password=desa");

            //optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["AppContext"].ConnectionString); //SystemConfiguration

            //var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false).Build();

            //optionsBuilder.UseSqlServer(config.GetConnectionString("AppContext")); //SystemConfiguration

            //optionsBuilder.UseSqlServer(
            //    "Server=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=True;"
            //);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(ele => ele.CategoryName)
                .HasMaxLength(15)
                .IsRequired();

            modelBuilder.Entity<Product>()
               .Property(ele => ele.ProductName)
               .HasMaxLength(40)
               .IsRequired();

            modelBuilder.Entity<Log>
                (
                    ele => {

                        ele.Property(p => p.Fecha)
                        .HasDefaultValueSql("getdate()");

                        ele.Property(p => p.Type)
                       .HasConversion(new EnumToStringConverter<LogType>())
                       .HasMaxLength(20);

                    }
                )
            ;

        }

    }
}
