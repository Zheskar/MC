﻿using ManaCena.Models;
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
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                ViewBag.SellerEnum = context.Sellers.ToList();
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditProduct(string seller, string name = "", string description = "")
        {
            List<int> lSeller = seller.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToList();
            name = name.ToLower();
            description = description.ToLower();
            List<Product> model = new List<Product>();
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                model = context.Products
                        .Include(o => o.Cathegory.CathegoryType)
                        .Include(o => o.SubCathegory.Cathegory.CathegoryType)
                        .Include(o => o.ProductImage)
                        .Include(o => o.ProductImageSmall)
                        .Include(o => o.ProductLocations)
                        .Where(o =>
                            (lSeller.Contains(o.Seller.Id))
                            //seller == "" || o.Seller == null || o.Seller.Name.ToLower().Contains(seller))
                            && (name == "" || o.Name.ToLower().Contains(name))
                            && (description == "" || o.Description.ToLower().Contains(description))
                         )
                        .ToList();

                ViewBag.SubCathegoryEnum = context.SubCathegories.ToList();
                ViewBag.CathegoryEnum = context.Cathegories.ToList();
                ViewBag.CathegoryTypeEnum = context.CathegoryTypes.ToList();
                ViewBag.SellerEnum = context.Sellers.Include(o => o.Locations).ToList();
            }

            return View(model);
        }

        [HttpPost]
        public bool EditItem(Product rec)
        {

            //ProductLocation peredajotsa, sledujushije shagi:
            //1) Proverj ne perezapisivajutsa li oni
            //2) Proverj, chtobi stiralis vse predidushije esli v nachale bili XX/X/XXX a potm pusto
            //2.1.) Sohranenije novoj zapisi
            //3) Otobrazhenije
            // 4) otobrazhenije v Detailes

            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                //dell all Locations (if any)
                context.ProductLocations.RemoveRange(context.ProductLocations.Where(o => o.ProductId == rec.Id));

                if (rec.ProductLocations.Count == context.Locations.Count(o => o.SellerId == rec.SellerId))
                {
                    rec.ProductLocations = null;
                }

                context.Products.Add(rec);
                if (rec.Id > 0)
                {
                    context.Entry(rec).State = System.Data.Entity.EntityState.Modified;
                    if (rec.ProductImage != null)
                    {
                        context.Entry(rec.ProductImage).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (rec.ProductImageSmall != null)
                    {
                        context.Entry(rec.ProductImageSmall).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        rec.ProductImageSmall = new ProductImageSmall();
                    }

                    rec.ProductImageSmall.Image = Helpers.ImageHelper.ResizeImage(rec.ProductImage.Image);

                    //// if same image in DB already, do not overwrite then
                    //var image = context.ProductImages.Where(o => o.Id == rec.ProductImageId).First();
                    //if (rec.ProductImage != null && image != null && image.Image != rec.ProductImage.Image)
                    //{
                    //    rec.ProductImageSmall = new ProductImageSmall { Image = Helpers.ImageHelper.ResizeImage(rec.ProductImage.Image) };
                    //}

                }
                else
                {
                    context.Entry(rec).State = System.Data.Entity.EntityState.Added;
                    context.Entry(rec.ProductImage).State = System.Data.Entity.EntityState.Added;
                    rec.ProductImage.Id = 0;
                    rec.ProductImageSmall = new ProductImageSmall { Image = Helpers.ImageHelper.ResizeImage(rec.ProductImage.Image) };
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
        public string GetImageSmall(int id)
        {
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                var rec = context.Products.Include(o => o.ProductImageSmall).Where(o => o.Id == id).FirstOrDefault();
                if (rec.ProductImageSmall != null && !string.IsNullOrEmpty(rec.ProductImageSmall.Image))
                {
                    return rec.ProductImageSmall.Image;
                }
                else
                {
                    return "";
                }
            }
        }

        [HttpGet]
        public ActionResult ProductView(int id)
        {
            Product model = null;
            using (ManaCenaEntities context = new ManaCenaEntities())
            {
                model = context.Products
                        .Include(o => o.Cathegory.CathegoryType)
                        .Include(o => o.SubCathegory.Cathegory.CathegoryType)
                        .Include(o => o.ProductImage)
                        //.Include(o => o.ProductImageSmall)
                        .Include(o => o.ProductLocations)
                        .Include(o => o.Seller)
                        .Include(o => o.Seller.SellerImage)
                        .Where(o =>o.Id ==id)
                        .First();
            }

            return PartialView(model);
            //return View(model);
        }        

    }
}