using ManaCena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace ManaCena.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditProduct()
        {
            List<Product> model = new List<Product>();
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                model = context.Products
                        .Include(o => o.Cathegory.CathegoryType)
                        .Include(o => o.ProductImage)
                        .Include(o => o.ProductImageSmall)
                        .ToList();
                ViewBag.CathegoryEnum = context.Cathegories.ToList();
                ViewBag.CathegoryTypeEnum = context.CathegoryTypes.ToList();
            }

            return View(model);
        }

        [HttpPost]
        public bool EditItem(Product rec)
        {
            using (ManaCenaEntities context = new ManaCenaEntities())
            {                
                context.Products.Add(rec);
                if (rec.Id > 0)
                {                    
                    context.Entry(rec).State = System.Data.Entity.EntityState.Modified;
                }
                else {
                    context.Entry(rec).State = System.Data.Entity.EntityState.Added;
                }
                // TODO: resize Iamge and 
                
                rec.ProductImageSmall = new ProductImageSmall { Image = Helpers.ImageHelper.ResizeImage(rec.ProductImage.Image) };
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

        [HttpGet]
        public string GetImageSmall(int id)
        {
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                var rec = context.Products.Include(o=>o.ProductImageSmall).Where(o=>o.Id == id).FirstOrDefault();
                if (rec.ProductImageSmall != null || !string.IsNullOrEmpty(rec.ProductImageSmall.Image))
                {
                    return rec.ProductImageSmall.Image;
                }
                else
                {
                    return "";
                }
            }
        }
    }
}