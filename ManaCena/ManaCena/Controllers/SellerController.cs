using ManaCena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ManaCena.Controllers
{
    public class SellerController : Controller
    {
        [HttpGet]
        public ActionResult EditSeller()
        {
            List<Seller> model = new List<Seller>();
            using (ManaCenaEntities context = new ManaCenaEntities())
            {

                model = context.Sellers
                        .Include(o => o.SellerImage)
                        .ToList();

            }
            return View(model);
        }

        [HttpPost]
        public bool EditSeller(Seller rec)
        {
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                context.Sellers.Add(rec);
                if (rec.Id > 0)
                {
                    context.Entry(rec).State = System.Data.Entity.EntityState.Modified;
                    if (rec.SellerImage != null)
                    {
                        if (rec.SellerImage.Id > 0)
                        {
                            context.Entry(rec.SellerImage).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            context.Entry(rec.SellerImage).State = System.Data.Entity.EntityState.Added; 
                        }
                    }
                }
                else
                {
                    context.Entry(rec).State = System.Data.Entity.EntityState.Added;
                    context.Entry(rec.SellerImage).State = System.Data.Entity.EntityState.Added;
                    rec.SellerImage.Id = 0;

                }
                context.SaveChanges();
            }
            return true;
        }

        [HttpPost]
        public bool DeleteSeller(int id)
        {
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                var rec = new Seller { Id = id };
                context.Entry(rec).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
            return true;
        }
    }
}
