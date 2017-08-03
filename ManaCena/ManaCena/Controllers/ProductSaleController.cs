﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManaCena.Models;
using System.Data.Entity;
using System.IO;
using System.Drawing;
using System.Web.Script.Serialization;

namespace ManaCena.Controllers
{
    public class ProductSaleController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditProductSale()
        {
            List<ProductSale> model = new List<ProductSale>();
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                model = context.ProductSales
                    .Include(o => o.Product)
                    .Include(o => o.Product.ProductImage)
                    //.Include(o => o.Product.ProductImage.Image)
                    .Include(o => o.Product.ProductImageSmall)
                    //.Include(o => o.Product.ProductImageSmall.Image)
                    .Include(o => o.Seller).ToList();
                ViewBag.SellerEnum = context.Sellers.ToList();
            }

            return View(model);
        }

        [HttpPost]
        public bool EditItem(ProductSale rec)
        {
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                context.ProductSales.Add(rec);
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
        public string GetQuickSearch(string term)
        {

            var model = new List<QuickSearcReponse>();

            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                model = context.Products
                        .Where(o=>o.Name.Contains(term))
                        .Select(o => new QuickSearcReponse { id = o.Id.ToString(), value =o.Name })
                        .OrderBy(o=>o.value)
                        .Take(10)
                        .ToList();
            }
            
            var json = new JavaScriptSerializer().Serialize(model);
            return json;
        }

        private class QuickSearcReponse
        {
            public string id { get; set; }
            public string value { get; set;}
        }

    }
}
