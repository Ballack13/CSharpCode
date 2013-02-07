using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTest.Models
{
    public class OrderDetail
    {
        public int SKU { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quatity { get; set; }

    }
}