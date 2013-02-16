using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcTest.ExtensionMethod
{
    interface IProduct
    {
         string ProductId { set; get; }
         string ProductName { set; get; }
         string Category { set; get; }
         decimal Price { set; get; }
        string GetProductName();
        string GetCategory();
        decimal GetPrice();
    }
}
