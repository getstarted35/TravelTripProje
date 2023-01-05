using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar; //Bunu admin panele veri cekebilmek için yazıyoruz

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();  
            return View(degerler);
        }
        [HttpGet] //sAYFA yüklenince hiç bir şey yapma sayfanın boş halini döndür demek
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]  
        public ActionResult YeniBlog(Blog p)  
        {
            c.Blogs.Add(p);  
            c.SaveChanges();  
            return RedirectToAction("Index");  
        }
        public ActionResult BlogSil(int id) 
        {
            var b = c.Blogs.Find(id);  
            c.Blogs.Remove(b);  
            c.SaveChanges();  
            return RedirectToAction("Index");  
        }
        public ActionResult BlogBul(int id) //blogbul a view ekledik
        {
            var bb = c.Blogs.Find(id);
            return View("BlogBul", bb);
        }
        public ActionResult BlogGüncelle(Blog b) //b isimli parametre ürettik
        {
            var bg = c.Blogs.Find(b.ID); //bg tanımlayıp b parametreID YE GÖRE bul dedik
            bg.Aciklama=b.Aciklama; //bg den gelen acıklamayı b acıklamaya göre al.
            bg.Tarih=b.Tarih;
            bg.Baslik = b.Baslik;
            bg.BlogImage = b.BlogImage;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi"); //Silme işlemlerinden sonra beni tekrar yorum sayfasına gönder dedik bir nevi. Layoutda da rota vermiştik.
        }
        public ActionResult YorumBul(int id)  /*View ekledik byrata*/
        {
            var yb = c.Yorumlars.Find(id);
            return View("YorumBul", yb);
        }
        public ActionResult YorumGüncelle(Yorumlar y) //y isimli parametre ürettik
        {
            var yg = c.Yorumlars.Find(y.ID); //yg tanımlayıp y parametreID YE GÖRE bul dedik
            yg.KullaniciAdı = y.KullaniciAdı; //yg den gelen Kullanıcıadi y Kullanıcıadı göre al.
            yg.Mail = y.Mail;
            yg.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");

        }
    }
}


//---NOTLARR-----

//Context c = new Context(); //Context'den c isimli bir nesne türettik

// var degerler = c.Blogs.ToList(); //değerleri listele c yazdık contextden o şekilde yukarda ürettik çünkü.


//        [HttpGet] //sAYFA yüklenince hiç bir şey yapma sayfanın boş halini döndür demek


//[HttpPost] //Post işlemi yaptığım zaman yani sayfaya bir şeyler gönderdiğim zaman aşağıdakileri döndür


//public ActionResult YeniBlog(Blog p) //Yukardakı ile aynı oldugundan ısmı blog'dan p isimli parametre ürettik.

// c.Blogs.Add(p); //c yani context'den ürettiğim p isimli parametre ekle dedik c.SaveChanges(); //kaydet dedik

//return RedirectToAction("Index"); //beni index action'una yönlendir dedik

//public ActionResult BlogSil(int id) //id parametresi gönderdik cunku silme işlemi id'ye göre ilerleyecek

//var b = c.Blogs.Find(id); //find yani bul diyoruz neyi bul id ye göre bul

//c.Blogs.Remove(b); //context blogs ve sil. neyi sil? b den gelen değeri

//