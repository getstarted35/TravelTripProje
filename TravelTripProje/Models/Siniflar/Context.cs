using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; 

namespace TravelTripProje.Models.Siniflar
{
    public class Context : DbContext //İlgili tablolara ulaşabilmek için böyle bir miras aldırma yapmamız gerek bu yüzden yazıyoruz.
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdresBlog> AdresBlogs { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Hakkimizda> Hakkimizdas { get; set; }
        public DbSet<iletisim> İletisims { get; set; }
        public DbSet<Yorumlar> Yorumlars { get; set; }

        //Normalde ingilizce yazmak çok daha doğru ancak türkçe iyi otursun diye bu seferlik yapmış bulundum
    }
}