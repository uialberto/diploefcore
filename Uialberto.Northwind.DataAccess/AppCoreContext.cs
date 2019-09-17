using Microsoft.EntityFrameworkCore;
using System;
using Uialberto.Northwind.Entities;

namespace Uialberto.Northwind.DataAccess
{
    public class AppCoreContext : DbContext
    {
        //public AppCoreContext(DbContextOptions<AppCoreContext> options) : base(options)
        //{

        //}
        //public virtual DbSet<Product> Products { get; set; }
        //public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().Ignore(ele => ele.RFC);
            modelBuilder.Entity<Employee>().HasKey(ele => new { ele.CompanyID, ele.EmployeeNumber });
            modelBuilder.Entity<Employee>().Property(ele => ele.FullName).HasComputedColumnSql("[FirstName]+ ',' +[LastName]"); // Columnas Calculadas

            //modelBuilder.Ignore<Product>();
            modelBuilder.Entity<Category>().Property(ele => ele.CategoryID).ValueGeneratedNever();
            modelBuilder.Entity<Category>().Property(ele => ele.Inserted).ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>().Property(ele => ele.LastUpdate).ValueGeneratedOnAddOrUpdate();

            
            modelBuilder.HasSequence<long>("EmployeCodeSequence", "sales")          // Sequence
                .StartsAt(10000)
                .IncrementsBy(1);

            modelBuilder.Entity<Employee>().Property(ele => ele.CodeSequence)       // Sequence
                .HasDefaultValueSql("Next value for sales.EmployeCodeSequence");


            //modelBuilder.Entity<Category>().HasIndex(ele => ele.CategoryName).HasName("Index_CategoryName");                                // Index 
            //modelBuilder.Entity<Category>().HasIndex(ele => ele.CategoryName).HasName("Index_CategoryName").IsUnique();                     // Valida que no sea null
            modelBuilder.Entity<Category>().HasIndex(ele => ele.CategoryName).HasName("Index_CategoryName").IsUnique().HasFilter(null);     // Permite null

            modelBuilder.Entity<Product>()
                .HasOne(ele => ele.Category)
                .WithMany(p => p.Products)
                .HasForeignKey("CategoryID")
                .HasConstraintName("ForeingKey_Product_Category");                      // Llaves Foraneas

            modelBuilder.Entity<Product>().Property(ele => ele.UnitsInStock).HasDefaultValue(10); // Valores por Defecto
            modelBuilder.Entity<Product>().Property(ele => ele.CreatedDate).HasDefaultValueSql("getdate()"); // Valores por Defecto


            modelBuilder.Entity<Category>()
                .HasAlternateKey(ele => ele.CategoryName)
                .HasName("AlternateKey_CategoryName");                                  // Clave Alterna (Restriccion Unique)
        }
        //
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Server=localhost;Database=aspnet-MVCAuthSQL;Trusted_Connection=False;MultipleActiveResultSets=true;User Id=SA;Password=my-secret-password;

            optionsBuilder.UseSqlServer("Server=.\\odin;Database=CoreNorthwindMod02;Trusted_Connection=False;User Id=desa;Password=desa",
                providerOptions => providerOptions.CommandTimeout(60) // Al ejecutar un comando, si pasa de 60 segudos, abortar
                ).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            //optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["AppContext"].ConnectionString); //SystemConfiguration

            //var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false).Build();

            //optionsBuilder.UseSqlServer(config.GetConnectionString("AppContext")); //SystemConfiguration

            //optionsBuilder.UseSqlServer(
            //    "Server=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=True;"
            //);
        }
    }
}
