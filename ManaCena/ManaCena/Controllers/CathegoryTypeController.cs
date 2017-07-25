using ManaCena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManaCena.Controllers
{
    public class CathegoryTypeController : Controller
    {

        [HttpGet]
        public ActionResult EditCathegoryType()
        {
            List<CathegoryType> model = new List<CathegoryType>();
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                model = context.CathegoryTypes.ToList();
            }
            return View(model);
        }

        [HttpPost]
        public bool EditCathegoryType(CathegoryType catType)
        {
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                context.CathegoryTypes.Add(catType);
                if (catType.Id > 0)
                {
                    context.Entry(catType).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    context.Entry(catType).State = System.Data.Entity.EntityState.Added;
                }
                context.SaveChanges();
            }
            return true;
        }

        [HttpPost]
        public bool DeleteCathegoryType(int id)
        {
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                var rec = new CathegoryType { Id = id };
                context.Entry(rec).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
            return true;
        }

    }
}
