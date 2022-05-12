using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kouzon_E_Ticaret.Models
{
    public class ShippingDetails
    {
       
        public string FullName { get; set; }
        [Required(ErrorMessage ="Lütfen adres tanımını giriniz.")]
        public string AdresBasligi { get; set; }
        [Required(ErrorMessage = "Lütfen adres bilginizi giriniz.")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Lütfen şehir giriniz.")]
        public string Sehir { get; set; }
        [Required(ErrorMessage = "Lütfen semt giriniz.")]
        public string Semt { get; set; }
        [Required(ErrorMessage = "Lütfen mahalle giriniz.")]
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }
    }
}