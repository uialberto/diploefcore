using System;
using System.Collections.Generic;
using System.Text;

namespace Uialberto.Northwind.Entities
{
    public class Product
    {
        public int ProductID { get; set; }        
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
