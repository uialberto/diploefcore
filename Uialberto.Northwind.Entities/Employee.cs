using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Uialberto.Northwind.Entities
{
    public class Employee
    {
        public int CompanyID { get; set; }
        public string EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; }
        //[Key]
        public string RFC { get; set; }

    }
}
