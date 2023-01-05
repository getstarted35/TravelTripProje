using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTripProje.Models.Siniflar
{
    public class BlogYorum
    { //biz buraya hangi tablodan veri çekeceksek o tabloları buraya IEnumerable olarak yazmak gerekiyor. Bu belli değerleri koleksıyon formatında toplayan yapıdır.

        public IEnumerable<Blog> Değer1 { get; set; }
        public IEnumerable<Yorumlar> Değer2 { get; set; }
        public IEnumerable<Blog> Değer3 { get; set; }

    }
}