using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Entity.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { set; get; }
    }

    public class LinqValueCalculator : IValueCalculator
    {
        IDiscountHelper discountHelper;
        public LinqValueCalculator(IDiscountHelper helper)
        {
            discountHelper = helper;
        }
        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return discountHelper.ApplyDiscount(products.Sum(m => m.Price));
        }
    }
}
