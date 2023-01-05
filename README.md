# TravelTripProje Murat Yücedağ'ın Eğitim serisinden tamamlanmıştır. Kendisine Teşekkür eder saygılarımı sunarım. Aşağıda yazmış olduğum notlar tamamen kendime yönelik projeyi geliştirirken öğrenme sürecimi hızlandırması için düşünülmüştür. Bu projelik türkçe class'lara yer verdim idare edin.

https://user-images.githubusercontent.com/93378523/210848695-76a971e0-82a9-4a48-834b-2b6e25ebcd07.mp4

1.asp.net web(entityframe work projesi açtık)

2.MVC ile çalışacağımız için seçtik ve ilerledik proje açıldı.

-Bize verilen hazır şablonu View içindeki index'i tarayıcıda açarak inceledik. Neler var neler yok.

-Kendimiz Shared klasörü içine Add View diyerek! _test Layaout'u(Sayfanın kaybolmayan tarafı Navbar gibi) açtık.  Kendisi Layout olduğu için Use Layout seçeneğini iptal ettik. Bunu sadece birine bağlı olduğunda seçiyoruz.

*Ancak bu halde tarayıcıda çalışmayacağını gördük. Bu yüzden controller ekledik(DefaultController) Controller içinde Bizi bir method karşılıyor. Index'e View ekleyerek Bunun hangi layout olduğunu bu sefer seçiyoruz. ve c# kodlarının @RenderBody() içinde olduğu yerde çalışacağını öğrendik. Aksi halde hata alırız.

3- Sonrasında hazır indirdiğimiz web temasının klasörünü proje ismine sürükle bırakarak eklemiş olduk

-Temayı ekledikten sonra TestLayout içine tema ındex kodlarından sabıt kalacaklar harıc(foother ve header) silerek yolumuza devam ediyoruz. Css-js dosya yolu farklı oldugu için ~/web/ ekleyerek düzelttik.

-Bu sefer iç kısımları yani content'i alıyoruz ve testlayout acınca viev ekledikten sonra cotroller'a bize bir ındex sayfası verıyordu Sonrasında Sayfanın başındaki Layout null 'u silip . Buraya content kodlarını yerleştırıyoruz. Bunu da temanın ındex'ini kopyalayıp kullanacağımız kısamlar harici silerek yapıyoruz. (head, headerbottom vs) ~Web yazarak lokasyonlarını belırtıyoruz fotoğrafların cuk oturuyor.

4-About sayfası için DefaultController sayfamıza bir ActionResult ekledik ancak bunun ismine About verip return olarak View Döndüreceğiz.
About'un View'ine Layout tanımlarken önceden yaptığımız gibi TestLayout'u kullanacağız.
5-TestLayout içinde link vereceğiz. Tıkladığımızda gitceğimiz yerleri. Değiştirdikten sonra about sayfasından Home a tıklayınca git geller düzeldi. Ve türkçeleştirme işlemleri yaptık.

6.DERSTE veritabanı için neler olduğunu listeledik. Tablo yapmamız için bölümlere ayırdık aşağıdaki gibi

---Anasayfa page için - hakkımızda section'ını belirledik
---Hakkımızda page için - hakkımızda yazısı-görseli olacak şekilde belirledik
---Blog bölümü için tablo
---İletişim page için tablo
---Admin olacak kullanıcı adı ve şifresi ile sisteme giriş yapcak

Bundan sonra classlarımızı yukarıdaki tablolara göre dolduruyoruz
(Anasayfa, Hakkımızda, Blog, İletişim, Yorumlar, Adres, Admin vs Models içinde Sınıflar Klasörü açıp içine class şeklinde ekliyoruz) 

*Aslında her biri tablo ve içinde özellikleri mevcut. Örneğin Anasayfa(Id, Başlık ve Açıklama) Şeklinde bu propları temamızın ve neyi tablolamak istediğimiz belirliyor

public ID {get; set;} Başına KEY koyarak değiştirilemez olarak belirledik.

8-İlişkiler içerisinde yer alan sınıflarımızı(classlarımızı) listelememiz için bir DbContext'E İhtiyacımız var bu yüzden bunu oluşturuyoruz. Entity Paketlerini yüklüyoruz.
*Sınıflar klasörü içine Context clası açtık paketleri projemize yükledik(EntityFramework) 
-Bunu contex clasına yazdık using Sytstem olarak.
-Devamında ilgili tablolara ulaşabilmek için context'in Db contexten miras alması gerekiyor bunun için Context:DbContext yazdık.
içine de listelemek istediğimiz sınıfları yazıyoruz ancak aşağıdaki gibi

''public DbSet<Admin> Admins {get; set;}''

9- Bloglar ve Yorumlar kısmında ilişki kuracağımız için oraya ayrı bir işlem yapıyoruz. 

Yorumlar Classı içine

public Blog Blog { get; set; } 

Blog isminde bir property tanımladık. Sebebi yorumlar kısmı için blog kısmından gelen değeri tutsun. Fakat bu işlemden sonra ilişki sağlanmıyor. Bu yüzden Yorumlar Sınıfına gidip onun proplarına aşağıdakini ekliyoruz

public ICollection<Yorumlar> Yorumlars {get; set}

ICollection bir interface Collection kümeleme anlamına geliyor aslında.

10.Ders olarak Connection String ile sql e bağlama işlemi gerçekleştiriyoruz. Bunu Web Config bölümünde entityframework bölümünde yazıyoruz en altta.

<connectionStrings>
		<add name="Context" connectionString="Data Source=DESKTOP-8M276D4; Initial Catalog=TravelDb; Integrated Security=TRUE;" providerName="System.Data.SqlClient"/>
	</connectionStrings>

11-Sonrasına Package Manager Console'a Enable-Migrations diyerek oluşturuyoruz. Fakat sayfadaki AutomaticMigrationsEnabled = true; yapmamız gerek. Normalde False geliyor. Devamında update-database dediğimizde sql de görebiliriz. 

Database diagram gelmediği için ona sql den new database diyoruz. Yorumlar ve blogları ekliyoruz. Çünkü onları birbirleri ile ilişkilendirdik.

About Sayfamız için hakkımızda sayfamız için aslında her sayfamız için ayrı controller tanımlamanın daha doğru olacağını düşündüğümüz için yeni bir AboutController tanımlayıp Indexını TestLayout ile ilişkilendiriyoruz.

-üst kısma sınıfları dahil ettik. Using bölümünden models.siniflar ekleyerek
ve iç kısıma önce c isminde nesne ürettik. Bu nesne ile Context'e bağlı olan sınıflardan hakkımizda ya ulaşıp onu döndürdük. Bu işlemleri nasıl yaptığımızı AboutController'a bakarak inceleybilirsiniz

-ABOUT ındex bölümünde, yine yukarıya bazı şeyler ekledik. Bunlar sayesinde sql tabloda yaptığımız değişiklikleri görebilmemizi sağlıyoruz.

@using TravelTripProje.Models.Siniflar  
@model List<Hakkimizda>  

ve alt kısımda forench döndürüyoruz. Aşağıdaki örnekte acıklama var ancak resim içinde aynı işlemi yaptık. Imgyukle sıtesnden url lınkını sql e gırdık ve sısteme @x.FotoUrl olarak aldık.

 @foreach (var x in Model)  

            {
                <p>@x.Aciklama</p>
            }

13- Bu süreçte sitemizin blog kısmı için yeni bir blog teması indirdik. Bunun için BlogController açtık, view ekledik ve temayı controller'a yerleştiriyoruz. Kullanacağımzı alan kadarını.

14- Bu süreçte blogta listemelek istediklerimizi listeliyoruz
Blog controller'ına gelerek üst kısma Sınıfları dahıl edıyoruz 
using methodu ile.
Sonrasında Context'i dahil ediyoruz. Contex c = new Context();
ve altınıda   public ActionResult Index()
        {
            var bloglar = c.Blogs.ToList();
            return View(bloglar);
        }
Şeklinde dolduruyoruz. Ve ındex blog bölümümüzün üst kısmına 
@using TravelTripProje.Models.Siniflar
@model List<Blog>
yazıyoruz.

Sonrasında Listelemek istediğimiz kısımlara Foreach oluşturuyoruz. Blog için düşünürsek, başlık, açıklama ve blog fotoğrafları. Bunları sql den tablodan değiştirince sitede anlık değişimi görebiliyoruz. 

15 - Blogla ilgili detay oluşturuyoruz. Yani blogun başlığına tıkladığımızda bizi ilgili sayfaya göndermesi için. Blog controller içine bir yeni action method oluşturup buna da detay ismini veriyoruz.
-Bunu ekledikten sonra add view diyerek elbette view eklememiz gerekiyor.
*ve bu durum bizim başlığımıza ve linke tıkladığımızda calısacağı için,
<a href="/Blog/BlogDetay/@x.ID">@x.Baslik'</a> şöyle bir işlem yaptık. blog sayfasının blog detay kısmında x.ıd methodu ile calıs dedik.

-Yorumlar kısmı 2.web temamızda olduğundan sıngle bölümünü komple kopyaladık ıcınde ışimize yarayacak olan kısımları aldık

16- Blog controller içini düzenliyoruz. Blog detay sayfamızın üst kısmına cağırmamız gerekenlerı dahil ediyorum(using proje ismi models. siniflar ve model List<Blog> nerede listeleyeceğimizi belirtip)
Sonrasında ise foreach acarak neyi döndürecek isek onları foreach içine alıyoruz. Blogtaki açıklama ve resim'i aldık.

17- Bazı bölümlerde değişikliklere gittik. Yeni classlar ekledik. Veri çekebilmemiz için. Projeyi yaparken şekillendirdiğimiz için böyle şeyler olabiliyor.

18 BlogYorum class'ı açtık. ve biz buraya hangi tablodan veri çekeceksek o tabloları buraya IEnumerable olarak yazmak gerekiyor. Bu belli değerleri koleksıyon formatında toplayan yapıdır.

Bu bölümde BlogController'da ki işlemleri inceleyin. Blogum Layout'unda tıkladıgımızda bizi karsılayan Blog Page içinde 4 tane yazı var.(roma, ist, paris, hamburg) Controller'da by(blogdetay) isminde nesne tanımladık. Amaç her blogu ayrı lıstelemektı. Bunun için yeni bir class açtık IEnumerable ekledik hepsi yukarıda anlattığım gibi.

19-Bu kısımda blogdaki yorumları listemelek için foreach döngüsüne alıp. Sql de girmiş olduğumuz kullanıcı adı ve yorumları gösterdik.

20-Son blogları görüntülüyebilmek için ayrı bir class oluşturuyoruz. Dediğim gibi siteyi güncelledikçe yeni classlar ekliyoruz.
Blog yorum'a IeNUREABLE ekleyip değer3 diyoruz. bu yan tarafta görünen son blogları göstermek için. Bu yaptığımız işlemler controllerda take yani göster komutuyla çağırıyoruz.

21- Anasayfaya geçtik slider'a blog resimlerini foreach döndürdük. Resim boyutları slider'a büyük geldiği için bazı düzenlemeler yaptık. ve veritabanınındaki resimleri slider da göstermiş olduk

22-Anasayfayı türkçeleştirdik. Temamızda bulunan bazı kısımları ayrı bir partial View e taşıyıp testLayout'dan ayrı bir alan oluşturmuş olduk. Bağımsız bir düzenleme gerçekleştirebilmek için. 

*Kullanacağımız bölümün html kodlarını kesip, default controller a yeni bir PartialViewResult oluşturup ismine Partial1 verdik içinde de return partialview() döndürdük. 

*Partial1 e yeni bir view ekledik ama testloyaut değil kendisi bir layout olacağı use layout dedik.

*kestiğimiz html kodların olduğu bölüme ise @Html.Action ("Partial1", "Default") yazarak açtığımız partial'ın kodlarını burada göstermiş olduk.

23-24: Partial içinde partial tanımladık. Anasayfa'da ki blog yazı görsellerini bölerek 2 tane görünmesini diğer partial'ın 1 tane olarak tek görünmesini gerçekleştirdik.

25: Burada ise Açıklama kısımlarını 50 karatere düşürerek anasayfa düzenleme işlemlerini gerçekleştiriyoruz. Bunu da foreach içinde belirlediğimiz açıklama kısmının sonun substring koyuyoruz yani (x.Aciklama.Substring(0,100) 

-Tarih formatları saat ile geldiği için bu formatları değiştirdik Bunuda foreach den cektiğimi tarihin yanına ekleyerek yaptık. Yani @x.Tarih.ToString("DD.MM.YY")

26-27: Bu bölümde En popüler 10 blog bölümünü listelemek için sql blogs tablolara 7 blog daha ekledik. Partial 3 açtık ve temanın 10 blog bölümüne @html.Action vererek yönlrini belirttik. Partial 3'de foreach e aldk. Numaraların sıralaması 1 1 artsın dıye int tanımlayıp ++ verdik

28: Bu bölümde Anasayfa'da en beğendiğim yerler bölümünde ki 6 adet blog u 3 sağ 3 sol olarak yıp partial içinde partial kullandık

29-30: Admin paneli için yeni bir controller actık.(admincontroller)
Yeni bir view ekledik shared'a kendi basına bir layout olcağı için hıc bır kutucugu secmıyoruz.
-AdmınController ıcındekı ındex'e bir view actık onuda adminlayout ile ilişkilendirdik.
-Admin panel html i indirdik. ve onu türkçeleştirip linklerini verdik

31-35: Bu bölümlerde Admin panelini düzenledik html tablolama yapıp ona uygun butona tıklandıgında gideceği rota yı belirttik
-extra olarak silme ekleme ve güncelleme işlemlerini yaptık. 

38-Yorum yapma işlemlerini gerçekleştirdik. Bunun için yeni bir partialView actık. bağlı olmayan.

SON---

Devamında projenin samee.com'dan yayınlanlası logout işlemleri gerçekleştirdik.


 




