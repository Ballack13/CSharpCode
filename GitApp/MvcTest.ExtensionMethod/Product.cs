using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcTest.ExtensionMethod
{
    public class Product:IProduct
    {
        public string ProductId { set; get; }
        public string ProductName { set; get; }
        public string Category { set; get; }
        public decimal Price { set; get; }

        public string GetProductName()
        {
            return ProductName;
        }

        public string GetCategory()
        {
            return Category;
        }

        public decimal GetPrice()
        {
            return Price;
        }

        public static bool GetBelowPrice(Product product)
        {
            if (product.Price <= 400)
            {
                return true;
            }
            else return false;
        }
        
    }
}
