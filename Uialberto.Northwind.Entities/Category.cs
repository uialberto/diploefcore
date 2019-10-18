using System;
using System.Collections.Generic;
using System.Text;

namespace Uialberto.Northwind.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }        
        public List<Product> Products { get; set; }
    }
}
