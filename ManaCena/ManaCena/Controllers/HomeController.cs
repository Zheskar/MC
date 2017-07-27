using ManaCena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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

        // TODO: perenseti etu hujnju v ProductController
        public ActionResult EditProduct()
        {
            List<Product> model = new List<Product>();
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                model = context.Products.Include(o => o.Cathegory.CathegoryType).Include(o => o.ProductImage).ToList();
                ViewBag.CathegoryEnum = context.Cathegories.ToList();
                ViewBag.CathegoryTypeEnum = context.CathegoryTypes.ToList();


                //model = context.Products.Include(o => o.Cathegory).ToList();
                var a = model[0].Cathegory.Name;
            }

            //foreach (System.Reflection.PropertyInfo prop in typeof(MyType).GetProperties())
            //{
            //    Console.WriteLine(prop.Name);
            //}
            return View(model);
        }
    }
}