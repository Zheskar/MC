using ManaCena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManaCena.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TestModel model = new TestModel();
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                model.p = context.Products.FirstOrDefault();
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}