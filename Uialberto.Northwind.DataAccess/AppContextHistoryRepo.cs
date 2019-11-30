using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.SqlServer.Migrations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Uialberto.Northwind.DataAccess
{
    public class AppContextHistoryRepo : SqlServerHistoryRepository
    {
        public AppContextHistoryRepo(HistoryRepositoryDependencies dependencies) : base(dependencies)
        {

        }
        protected override void ConfigureTable(EntityTypeBuilder<HistoryRow> history)
        {
            base.ConfigureTable(history);
            history.Property(h => h.MigrationId).HasColumnName("ID");
        }
    }
}
