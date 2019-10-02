using System;
using System.Collections.Generic;
using System.Text;
using Uialberto.Northwind.Entities;

namespace Uialberto.Northwind.Services
{
    public interface ILogRepo
    {
        List<Log> GetAll();
    }
}
