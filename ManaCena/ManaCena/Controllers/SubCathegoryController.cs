using ManaCena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManaCena.Controllers
{
    public class SubCathegoryController : Controller
    {
        [HttpGet]
        public ActionResult EditSubCathegory()
        {
            List<SubCathegory> model = new List<SubCathegory>();
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                model = context.SubCathegories.ToList();
                ViewBag.CathegoryEnum = context.Cathegories.ToList();
            }
            return View(model);
        }

        [HttpPost]
        public bool EditSubCathegory(SubCathegory rec)
        {
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                context.SubCathegories.Add(rec);
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
        public bool DeleteSubCathegory(int id)
        {
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                var rec = new SubCathegory { Id = id };
                context.Entry(rec).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
            return true;
        }

    }
}