using ManaCena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManaCena.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public bool EditItem(Product a)
        {
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                context.Products.Add(a);
                context.Entry(a).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            return true;
        }

    }
}