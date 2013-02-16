using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcTest.ExtensionMethod
{
    static class ProductInterfaceExtension
    {
        public static string GetProductInfo(this IProduct product)
        {
            return "ProductName:" + product.ProductName + "\tCategory:" + product.Category + "\tPrice:" + product.Price.ToString();
        }
    }
}
