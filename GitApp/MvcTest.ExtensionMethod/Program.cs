using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcTest.ExtensionMethod;

namespace MvcTest.ExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is the list of product");
            IEnumerable<Product> products = new List<Product>{
                new Product(){ProductId="Clothes13",ProductName="Ballack T shirt",Price=598M,Category="Clothes"},
                new Product(){ProductId="Clothes1",ProductName="Kahn T shirt",Price=759M,Category="Clothes"},
                new Product(){ProductId="12345",ProductName="Euro Football",Price=199M,Category="Sports"},
                new Product(){ProductId="84512",ProductName="Visual Studio 2012 Ultimate",Price=235M,Category="Software"}
            };
            IEnumerable<Product> temp=products.GetByCategory("Clothes");
            foreach (Product product in temp)
            {
                Console.WriteLine(product.GetProductInfo());
            }

            Console.WriteLine("These products's price below 200 RMB....");
            Func<Product, bool> lowPriceFilter = delegate(Product pro) { if (pro.Price <= 200M)return true; else return false; };
            Func<Product, bool> lambdaLowPriceFilter = prod => prod.Price <= 200M;
            IEnumerable<Product> belowProducts = products.Filter(lambdaLowPriceFilter);
            foreach (Product product in belowProducts)
            {
                Console.WriteLine(product.GetProductInfo());
            }
            Console.ReadLine();


            
        }
    }
}
