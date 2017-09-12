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

                //ViewBag.CathegoryTypeEnum = context
                //    .CathegoryTypes
                //    .Include(o => o.Cathegories.Select(q => q.SubCathegories)).ToList()
                //    .ToList();

                var menuList = context
                    .CathegoryTypes
                    .Include(o => o.Cathegories.Select(k => k.SubCathegories))
                    .OrderBy(o => o.Name)
                    .ToList();

                // lame order by, EF cna't hande a shit
                foreach (var team in menuList)
                {
                    team.Cathegories = team.Cathegories.OrderBy(m => m.Name).ToList();
                    foreach (var teamMember in team.Cathegories)
                    {
                        teamMember.SubCathegories = teamMember.SubCathegories.OrderBy(u => u.Name).ToList();
                    }
                }

                ViewBag.CathegoryTypeEnum = menuList;

                ViewBag.CathegoryEnum = context.Cathegories.ToList();
                ViewBag.SubCathegoryEnum = context.SubCathegories.ToList();

                ViewBag.SellerEnum = context.Sellers.ToList();

                //ViewBag.CathegoryEnum = context.Cathegories.Include(o => o.CathegoryType).OrderBy(o => o.CathegoryType.Name).ToList();
            }

            return View();
        }


        //[HttpGet]
        [HttpPost]
        public ActionResult Search(List<int> sellersList, string search = "", Nullable<int> subCathegoryId = null, Nullable<int> cathegoryId = null, Nullable<int> cathegoryTypeId = null)
        {
            List<Product> model = new List<Product>();
         
            if (sellersList == null)
            {
                sellersList = new List<int>();
            }

            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                model = context.Products
                    //.Include(o => o.ProductImage)
                    .Include(o => o.ProductImageSmall)
                    .Include(o => o.Seller)
                    .Include(o => o.Seller.SellerImage)
                    .Where(o =>
                         (o.SubCathegoryId == subCathegoryId || subCathegoryId == null) &&
                        (o.CathegoryId == cathegoryId || cathegoryId == null) &&
                        (o.CathegoryTypeId == cathegoryTypeId || cathegoryTypeId == null) &&
                        (sellersList.Count == 0 || sellersList.Contains(o.SellerId))
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