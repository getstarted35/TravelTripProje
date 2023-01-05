using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers  
{
    public class DefaultController : Controller  
    {
        // GET: Default
        Context c = new Context();
        public ActionResult Index() 
        {
            var degerler = c.Blogs.Take(4).ToList();
            return View(degerler); 
        }

        public ActionResult About()
        {
            return View();
        }

        public PartialViewResult Partial1()  
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(2).ToList(); 
            return PartialView(degerler);
        }
        public PartialViewResult Partial2()
        {
            var deger = c.Blogs.Where(x => x.ID==1).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial3()
        {
            var deger = c.Blogs.Take(10).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial4() //Partial içinde partial yaptık 3 sağ 3 sol tarafta görünsün diye
        {
            var deger = c.Blogs.Take(3).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial5()
        {
            var deger = c.Blogs.Take(3).OrderByDescending(x => x.ID).ToList(); //Bana a dan z ye doğru sırala sadece 3 tanesını göster.
            return PartialView(deger);
        }
    }
}


//NOTLARRR


//using System.Web.Mvc; //Kontrollerı ekledıktan sonra üst tarafa sistemden hazır bazı kütüphaneler gelir.


//namespace TravelTripProje.Controllers //Burada proje ismimiz ve bağlı olduğu alan yani controllers


//public ActionResult Index() //Bu ise bir method. İsmi Index, tipi ActionResult türünde yani aksiyon sonucu Erişim türü public(diğer sayfalardan ulaşılır.)

//return View(degerler); //ve bu method geriye 1 tane sayfa döndürüyor. Bunun hangi sayfayı döndürğünü belirlemek için için index'e sağ tık yapıp add View diyoruz. Bu işlemden sonra Testlayout'u kullnacağı için onu seçiyoruz. Sonucta bize bir index sayfası veriyor

// public PartialViewResult Partial1() //Bu bölüm anasayfa kısmında blogların görüntülenmesi için oluşturduğumuz bir kısımdır.


// var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(2).ToList(); z'den a ya doğru sıralar  2 tane göster diyoruz