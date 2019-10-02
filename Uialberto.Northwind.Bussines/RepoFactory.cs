using System;
using System.Collections.Generic;
using System.Text;
using Uialberto.Northwind.Services;

namespace Uialberto.Northwind.Bussines
{
    public class RepoFactory
    {
        public static ICategoryRepo GetCategoryRepo()
        {
            return new CategoryRepo();
        }

        public static ILogRepo GetLogRepo()
        {
            return new LogRepo();
        }
    }
}
