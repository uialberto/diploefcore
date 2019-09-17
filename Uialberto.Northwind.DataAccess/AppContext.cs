using Microsoft.EntityFrameworkCore;
using System;
using Uialberto.Northwind.Entities;

namespace Uialberto.Northwind.DataAccess
{
    public class AppContext : DbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Vendedor> Vendedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Server=localhost;Database=aspnet-MVCAuthSQL;Trusted_Connection=False;MultipleActiveResultSets=true;User Id=SA;Password=my-secret-password;
            optionsBuilder.UseSqlServer("Server=.\\odin;Database=CoreNorthwindHerencia;Trusted_Connection=False;User Id=desa;Password=desa");

            //optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["AppContext"].ConnectionString); //SystemConfiguration

            //var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false).Build();

            //optionsBuilder.UseSqlServer(config.GetConnectionString("AppContext")); //SystemConfiguration

            //optionsBuilder.UseSqlServer(
            //    "Server=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=True;"
            //);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employee>()
            //    .HasDiscriminator<byte>("EmployeeType")   // Propiedades Sombra
            //    .HasValue<Employee>(0)
            //    .HasValue<Vendedor>(1);

            //modelBuilder.Entity<Employee>()
            //   .HasDiscriminator(ele => ele.EmployeeType)
            //   .HasValue<Employee>(0)
            //   .HasValue<Vendedor>(1);

            modelBuilder.Entity<Employee>(
                    ele => {

                        ele.HasDiscriminator(ed => ed.EmployeeType)
                        .HasValue<Employee>(0)
                        .HasValue<Vendedor>(1);

                        ele.Property(ed => ed.EmployeeType)
                        .HasDefaultValue(0)
                        .HasColumnName("Type");
                    }
                );

            modelBuilder.Entity<Employee>()
                .HasData(
                    new Employee { EmployeeID = 1, FirstName = "Alberto", LastName="Reyes"},
                    new Employee { EmployeeID = 2, FirstName = "Fernando", LastName = "Baigorria" }
                );

            modelBuilder.Entity<Vendedor>()
             .HasData(
                 new Vendedor { EmployeeID = 3, FirstName = "Milton", LastName = "Lazo", SellingAreaID = 1 },
                 new Vendedor { EmployeeID = 4, FirstName = "Wilson", LastName = "Lazo" , SellingAreaID = 2}
             );
        }
    }
}
