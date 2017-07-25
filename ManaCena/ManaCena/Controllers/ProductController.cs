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

        public bool EditItem(Product product)
        {
            using (ManaCenaEntities context = new ManaCenaEntities())
            {                
                context.Products.Add(product);
                if (product.Id > 0)
                {                    
                    context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                }
                else {
                    context.Entry(product).State = System.Data.Entity.EntityState.Added;
                }
                context.SaveChanges();
            }
            return true;
        }

        [HttpPost]
        public bool DeleteItem(int id)
        {
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                var rec = new Product { Id = id };
                context.Entry(rec).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
            return true;
        }

    }
}