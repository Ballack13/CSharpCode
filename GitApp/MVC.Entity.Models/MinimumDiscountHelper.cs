using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Entity.Models
{
    public class MinimumDiscountHelper:IDiscountHelper
    {
        public decimal ApplyDiscount(decimal totalParam)
        {
            if (totalParam < 0M)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (totalParam < 10M)
            {
                return totalParam;
            }
            else if (totalParam <= 100M)
            {
                return totalParam -5M;
            }
            else
            {
                return totalParam * 0.9M;
            }
            //throw new NotImplementedException();
        }
    }
}
