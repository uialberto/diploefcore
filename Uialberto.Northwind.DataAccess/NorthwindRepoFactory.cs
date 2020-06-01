using System;
using System.Collections.Generic;
using System.Text;
using Uialberto.Northwind.Services;

namespace Uialberto.Northwind.DataAccess
{
    public static class NorthwindRepoFactory
    {
        public static INorthwindRepo GetNorthwindRepo(bool isUow = false)
        {
            return new NorthwindRepo(isUow);
        }
    }
}
