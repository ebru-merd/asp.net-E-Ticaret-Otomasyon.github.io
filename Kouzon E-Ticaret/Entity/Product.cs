using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Kouzon_E_Ticaret.Entity
{
    public class Product
    {
        public int Id { get; set; }

        [DisplayName("Ürün Adı")]
        public string Name { get; set; }
        [DisplayName("Ürün Açıklaması")]
        public string Description { get; set; }
        [DisplayName("Fiyat")]
        public double Price { get; set; }
        [DisplayName("Stok")]
        public int Stock { get; set; }
        [DisplayName("Resim")]
        public string Image { get; set; }

        [DisplayName("Anasayfa")]
        public bool IsHome { get; set; }
        [DisplayName("Satışta")]
        public bool IsApproved { get; set; }

        [DisplayName("Kategori")]
        public int CategoryId { get; set; } // FK(Yabancı Anahtar)
        public Category Category { get; set; }
    }
}