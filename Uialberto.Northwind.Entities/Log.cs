using System;
using System.Collections.Generic;
using System.Text;

namespace Uialberto.Northwind.Entities
{
    public enum LogType
    {
        DeleteCategory
    }
    public class Log
    {
        public int LogID { get; set; }
        public DateTime Fecha { get; set; }
        public LogType Type { get; set; }
        public string Message { get; set; }
    }
}
