using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.RazorEngine.Models;

namespace MVC.RazorEngine.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        Product myProduct = new Product
        {
            ProductID = 1,
            Name = "Kayak",
            Description = "A boat for one person",
            Category = "Watersports",
            Price = 275M
        };

        public ActionResult Index()
        {
            return View(myProduct);
        }

        public ActionResult DemoExpression()
        {
            ViewBag.ProductCount = 0;
            return View(myProduct);
        }

        public ActionResult DemoArray()
        {
            Product[] array = {
                                new Product {Name = "Kayak", Price = 275M},
                                new Product {Name = "Lifejacket", Price = 48.95M},
                                new Product {Name = "Soccer ball", Price = 19.50M},
                                new Product {Name = "Corner flag", Price = 34.95M}
                               };
            return View(array);
        }

    }
}
