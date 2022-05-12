using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Kouzon_E_Ticaret.Entity
{
    public class Category
    {
        [DisplayName("Kategori")]
        public int Id { get; set; }

        [DisplayName("Kategori Adı") ]
        //[StringLenght(maximumLenght:20, ErrorMessage = "En Fazla 20 Karakter Girebilirsiniz")] (Hata veriyor)
        public string Name { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }

    internal class StringLenghtAttribute : Attribute
    {
    }
}