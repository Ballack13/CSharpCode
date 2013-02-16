using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcTest.ExtensionMethod
{
    public static class FilterByCategory
    {
        public static IEnumerable<Product> GetByCategory(this IEnumerable<Product> list, string categoryName)
        {
            foreach (Product item in list)
            {
                if (item.Category.ToLower().Trim() == categoryName.Trim().ToLower())
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<Product> Filter(this IEnumerable<Product> list, Func<Product, bool> filter)
        {
            foreach (Product item in list)
            {
                if (filter(item))
                {
                    yield return item;
                }
            }
        }
    }
}
