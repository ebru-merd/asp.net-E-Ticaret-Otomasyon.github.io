using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kouzon_E_Ticaret.Entity;
using Kouzon_E_Ticaret.Models;

namespace Kouzon_E_Ticaret.Controllers
{
    public class CartController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);

            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }

            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);

            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }

            return RedirectToAction("Index");
        }
        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

        [Authorize]
        public ActionResult Checkout(ShippingDetails entity)
        {
            var cart = GetCart();
            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("UrunYokError", "Sepetinizde ürün bulunmamaktadır.");
            }
            if (ModelState.IsValid)
            {
                //siparişi veritabanına kayıt et.
                //cart' sıfırla
                SaveOrder(cart, entity);
                cart.Clear();
                return View("Completed");

            }
            else
            {
                return View(entity);
            }

        }


        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var Order = new Order();

            Order.OrderNumber = "A" + (new Random()).Next(11111, 99999).ToString();
            Order.Total = cart.Total();
            Order.OrderDate = DateTime.Now;
            Order.OrderState = EnumOrderState.Waiting;
            Order.FullName = entity.FullName;
          
            Order.AdresBasligi = entity.AdresBasligi;
            Order.Adres = entity.Adres;
            Order.Sehir = entity.Sehir;
            Order.Semt = entity.Semt;
            Order.Mahalle = entity.Mahalle;
            Order.PostaKodu = entity.PostaKodu;

            Order.OrderLines = new List<OrderLine>();
            foreach (var pr in cart.CartLines)
            {
                var orderLine = new OrderLine();
                orderLine.Quantity = pr.Quantity;
                orderLine.Price =pr.Quantity * pr.Product.Price;
                orderLine.ProductId = pr.Product.Id;

                Order.OrderLines.Add(orderLine);
            }
            db.Orders.Add(Order);
            db.SaveChanges();
        }
    }
}