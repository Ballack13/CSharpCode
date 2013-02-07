using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTest.Models;

namespace MvcTest.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            Order order = Order.GetDefaultOrder();
            return View(order);
        }

        public ActionResult Login()
        {
            User user = MvcTest.Models.User.GetDefaultUser();
            return View(user);
        }

        public JsonResult UserExist(string UserName)
        {
            var result = MvcTest.Models.User.GetUser(UserName) == null;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
