using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Kouzon_E_Ticaret.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            {
                new Category(){ Name = "Elektronik", Description = "Elektronik Ürünleri"},
                new Category(){ Name = "Moda", Description = "Moda Ürünleri"},
                new Category(){ Name = "Ev & Yaşam", Description = "Ev & Yaşam Ürünleri"},
                new Category(){ Name = "Spor", Description = "Spor Ürünleri"},
                new Category(){ Name = "Kitap", Description = "Kitap Ürünleri"},
                new Category(){ Name = "Kişisel Bakım", Description = "Kişisel Bakım Ürünleri"}
            };

            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();

            var urunler = new List<Product>()
            {
                new Product(){ Name = "Apple Macbook Pro" ,Description = "Apple Macbook Pro 14'İnç", Price = 22000, Stock = 5, IsApproved = true, CategoryId = 1, IsHome = true, Image = "1.jpg"},
                new Product(){ Name = "Apple Airpods" ,Description = "Apple Airpods", Price = 3.999, Stock = 10, IsApproved = true, CategoryId = 1, IsHome = false, Image = "1.jpg"},

                new Product(){ Name = "Zara Elbise" ,Description = "Zara Kırmızı Elbise", Price = 379.99, Stock = 20, IsApproved = true, CategoryId = 2, IsHome = true, Image = "3.jpg"},
                new Product(){ Name = "Bershka Tulum" ,Description = "Bershka bahçıvan tulum", Price = 250, Stock = 1, IsApproved = false, CategoryId = 2, IsHome = false, Image = "4.jpg"},

                new Product(){ Name = "Koltuk" ,Description = "Kırmızı deri koltuk", Price = 15.000, Stock = 3, IsApproved = true, CategoryId = 3, IsHome = true, Image = "1.jpg"},
                new Product(){ Name = "Saksı" ,Description = "Bitki için saksı", Price = 45, Stock = 20, IsApproved = true, CategoryId = 3, IsHome = false, Image = "1.jpg"},

                new Product(){ Name = "Tenis Raketi" ,Description = "Wilson Raket", Price = 1.999, Stock = 5, IsApproved = true, CategoryId = 4, IsHome = true, Image = "3.jpg"},
                new Product(){ Name = "Paten" ,Description = "40 numara paten", Price = 2000, Stock = 5, IsApproved = true, CategoryId = 4, IsHome = false, Image = "4.jpg"},

                new Product(){ Name = "İnsan Ne ile Yaşar" ,Description = "Tolstoy", Price = 15.99, Stock = 5, IsApproved = false, CategoryId = 5, IsHome = true, Image = "1.jpg"},
                new Product(){ Name = "Kürk Mandolu Madonna" ,Description = "Yazar: Yiğit Ebru", Price = 250, Stock = 5, IsApproved = false, CategoryId = 5, IsHome = false, Image = "3.jpg"},

                new Product(){ Name = "Nivea El Kremi" ,Description = "Nivea El Kremi", Price = 49.99, Stock = 30, IsApproved = true, CategoryId = 6, IsHome = true, Image = "3.jpg"},
                new Product(){ Name = "Pantene Şampuan" ,Description = "Hacimli Saçlar için", Price = 29.99, Stock = 100, IsApproved = true, CategoryId = 6, IsHome = false, Image = "4.jpg"}
            };
            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}