﻿using ManaCena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManaCena.Controllers
{
    public class CathegoryController : Controller
    {
        [HttpGet]
        public ActionResult EditCathegory()
        {
            List<Cathegory> model = new List<Cathegory>();
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                model = context.Cathegories.ToList();
                ViewBag.CathegoryTypeEnum = context.CathegoryTypes.ToList();
            }
            return View(model);
        }

        [HttpPost]
        public bool EditCathegory(Cathegory rec)
        {
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                context.Cathegories.Add(rec);
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
        public bool DeleteCathegory(int id)
        {
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                var rec = new Cathegory { Id = id };
                context.Entry(rec).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
            return true;
        }
    }
}
