using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProje.Models.Siniflar
{
    public class Blog //Sınıflar bölümünde açtığımız classı sayfalarda neyi tablolayacaksak ona göre belirliyoruz.
    {
        [Key]
        public int ID { get; set; }
        public string Baslik { get; set; }
        public DateTime Tarih { get; set; }
        public string Aciklama { get; set; }
        public string BlogImage { get; set; }
        public ICollection<Yorumlar> Yorumlars { get; set; } //Bu bize yorumlar ve bloglar sayfasında ilişki sağlayacak. Bir blogun 1 den fazla yorumu olabilir. Ama 1 yorum sadece 1 blog için geçerli olabilir.
    }
}