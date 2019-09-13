using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uialberto.Northwind.Entities
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        //[Key]
        public string RFC { get; set; }
        public string EmployeeNumber { get; set; }

    }
}
