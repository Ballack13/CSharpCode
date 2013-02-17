using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Entity.Models
{
    public class FlexibleDiscountHelper:IDiscountHelper
    {
        public decimal ApplyDiscount(decimal totalParam)
        {
            decimal discount = totalParam > 100M ? 70M : 25M;
            return totalParam - (discount / 100M * totalParam);
        }
    }
}
