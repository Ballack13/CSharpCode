using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Entity.Models;
using Ninject;

namespace MVC.EssentialTool.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private IValueCalculator cal;

        public HomeController(IValueCalculator calcParam)
        {
            cal = calcParam;
        }

        private Product[] products ={
                                       new Product{Name="Ballack",Category="Germany",Price=5000M},
                                       new Product{Name="Ribery",Category="France",Price=4532M},
                                       new Product{Name="Muller",Category="Germany",Price=3012M},
                                       new Product{Name="Kahn",Category="Germany",Price=4999M},
                                       new Product{Name="Alaba",Category="Austra",Price=2351M}
                                   };


        public ActionResult Index()
        {
            //LinqValueCalculator cal = new LinqValueCalculator();
            //IKernel ninjectKernel = new StandardKernel();
            //ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            //IValueCalculator cal = ninjectKernel.Get<IValueCalculator>();
            ShoppingCart cart = new ShoppingCart(cal) { Products = products };
            decimal totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }

    }
}
