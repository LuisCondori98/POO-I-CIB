using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appWeb_T2_CondoriAnaya.Models
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set;}
        public string CategoryName { get; set; }
        public string CompanyName { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public double StockValorizado { get; set; }

    }
}