using ManaCena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ManaCena.Controllers
{
    public class SearchProductController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<Product> model = new List<Product>();
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                ViewBag.CathegoryEnum = context.Cathegories.Include(o => o.CathegoryType).OrderBy(o=>o.CathegoryType.Name).ToList();
                //ViewBag.CathegoryTypeEnum = context.CathegoryTypes.Include(o => o.Cathegories).OrderBy(o => o.Name).ToList();
            }

            return View();
        }


        [HttpGet]
        public ActionResult Search(string search = "", Nullable<int> cathegoryId = null)
        {
            List<Product> model = new List<Product>();
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                model = context.Products
                    //.Include(o => o.ProductImage)
                    .Include(o => o.ProductImageSmall)
                    .Include(o => o.Seller)
                    .Include(o => o.Seller.SellerImage)
                    .Where(o =>
                         (o.CathegoryId == cathegoryId || cathegoryId == null) &&
                        (o.Name.Contains(search) || o.Description.Contains(search))
                    ).ToList();                
            }

            return PartialView("ProductDashboard", model);
        }


        [HttpGet]
        public string GetLargeImage(int id)
        {
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                var img = context.ProductImages.Where(o => o.Id == id).Select(o => o.Image).First();
                return img;
            }
            
        }
        


    }
}