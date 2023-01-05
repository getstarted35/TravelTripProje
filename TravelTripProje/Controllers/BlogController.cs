using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogYorum by = new BlogYorum(); //by blog yorum kısaltması anlamında nesne tanımladık burada
        public ActionResult Index()
        {
            //var bloglar = c.Blogs.ToList();
            by.Değer1 = c.Blogs.ToList();
            by.Değer3 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList(); //Son bloglar ıcın tanımladıdımız değer 3 ü listeledik
            return View(by);
        }
       
        public ActionResult BlogDetay(int id) //Buraya blog sayfamızın detay kısmı için actionresult bölümü oluşturduk. Ve int id TÜRÜNDE parametre aldı.
        {
            by.Değer1 = c.Blogs.Where(x => x.ID == id).ToList();
            by.Değer2 = c.Yorumlars.Where(x => x.BlogId == id).ToList();
            
            //var blogbul = c.Blogs.Where(x=>x.ID == id).ToList(); //x eşittir büyüktür.x öyle ki blogun ID'si ===                                                    
            return View(by);                               
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y) //y isimli parametre ürettik
        {
            c.Yorumlars.Add(y); //contexten al y ye göre ekle dedik
            c.SaveChanges(); //kaydet
            return PartialView();  //beni indexe yönlendir.

        }



    }
}