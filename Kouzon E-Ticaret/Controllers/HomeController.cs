using Kouzon_E_Ticaret.Entity;
using Kouzon_E_Ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kouzon_E_Ticaret.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext();


        // GET: Home
        public ActionResult Index()
        {
            var urunler = _context.Products
              .Where(i => i.IsHome && i.IsApproved)
              .Select(i => new ProductModel()
              {
                  Id = i.Id,
                  Name = i.Name.Length > 23 ? i.Name.Substring(0, 20) + "..." : i.Name,
                  Description = i.Description.Length > 35 ? i.Description.Substring(0, 32) + "..." : i.Description,
                  Price = i.Price,
                  Stock = i.Stock,
                  Image = i.Image,
                  CategoryId = i.CategoryId
              }).ToList();

            return View(urunler);
        }
        public ActionResult Urun(int id)
        {
            return View(_context.Products.Where(i => i.Id == id).FirstOrDefault());
        }
        public ActionResult Sepet()
        {
            return View();
        }
        public ActionResult Siparis()
        {
            return View();
        }
        public ActionResult SiparisOnay()
        {
            return View();
        }
        public ActionResult UrunList(int? id)
        {
            var urunler = _context.Products
              .Where(i => i.IsApproved)
              .Select(i => new ProductModel()
              {
                  Id = i.Id,
                  Name = i.Name.Length > 23 ? i.Name.Substring(0, 20) + "..." : i.Name,
                  Description = i.Description.Length > 25 ? i.Description.Substring(0, 22) + "..." : i.Description,
                  Price = i.Price,
                  Stock = i.Stock,
                  Image = i.Image == null?"1.jpg" : i.Image,
                  CategoryId = i.CategoryId
              }).AsQueryable(); //Çalışmamış Sorguya ekstradan filtre ekleyebiliyoruz.

            if (id != null)
            {
                urunler = urunler.Where(i => i.CategoryId == id);
            }

            return View(urunler.ToList());
        }
        public PartialViewResult GetCategories()
        {
            return PartialView(_context.Categories.ToList());
        }
    }
}