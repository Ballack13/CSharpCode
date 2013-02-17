using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Entity.Models
{
    public class DefaultDiscountHelper:IDiscountHelper
    {
        public decimal DiscountSize { set; get; }
        public decimal ApplyDiscount(decimal totalDiscount)
        {
           
            return totalDiscount - (DiscountSize / 100M * totalDiscount);
        }
    }
}
