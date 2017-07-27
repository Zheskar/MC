using ManaCena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManaCena.Controllers
{
    public class LocationController : Controller
    {

        [HttpGet]
        public ActionResult EditLocation()
        {
            List<Location> model = new List<Location>();
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                model = context.Locations.ToList();
            }
            return View(model);
        }

        [HttpPost]
        public bool EditLocation(Location rec)
        {
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                context.Locations.Add(rec);
                if (rec.Id > 0)
                {
                    context.Entry(rec).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    context.Entry(rec).State = System.Data.Entity.EntityState.Added;
                }
                context.SaveChanges();
            }
            return true;
        }

        [HttpPost]
        public bool DeleteLocation(int id)
        {
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                var rec = new Location { Id = id };
                context.Entry(rec).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
            return true;
        }

    }
}
