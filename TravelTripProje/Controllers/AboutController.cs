using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Context c = new Context(); //Context kısmından c isminde yeni nesne üret dedik
        public ActionResult Index()
        {
            var degerler = c.Hakkimizdas.ToList(); //bu ürettiğimiz c yardımı ile de Context'e bağlı sınıflarımızdan Hakkimizda yı listeledik
            return View(degerler); //hakkımızda listesini döndürdük
        }
    }
}