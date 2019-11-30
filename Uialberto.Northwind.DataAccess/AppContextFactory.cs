using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Uialberto.Northwind.DataAccess
{
    public class AppContextFactory : IDesignTimeDbContextFactory<AppContext>
    {
        public AppContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppContext>();
            optionsBuilder.UseSqlServer("Server=.\\odin;Database=NorthwindDbCreate;Trusted_Connection=False;User Id=desa;Password=desa", x=> x.CommandTimeout(60));

            return new AppContext(optionsBuilder.Options);
        }
    }
}
