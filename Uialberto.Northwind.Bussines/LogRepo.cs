using System;
using System.Collections.Generic;
using System.Text;
using Uialberto.Northwind.DataAccess;
using Uialberto.Northwind.Entities;
using Uialberto.Northwind.Services;

namespace Uialberto.Northwind.Bussines
{
    public class LogRepo : ILogRepo
    {
        public List<Log> GetAll()
        {
            return NorthwindRepoFactory.GetNorthwindRepo().GetLogs();
        }
    }
}
