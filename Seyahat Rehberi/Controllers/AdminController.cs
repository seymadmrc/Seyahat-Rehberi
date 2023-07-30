using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Seyahat_Rehberi.Models.Sınıflar;

namespace Seyahat_Rehberi.Controllers
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
        [HttpGet]
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
        public ActionResult BlogSil(int ID)
        {
            var b = c.Blogs.Find(ID);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int ID)
        {
            var bl = c.Blogs.Find(ID);
            return View("BlogGetir", bl);
        }
        public ActionResult BlogGüncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);

        }
        public ActionResult YorumSil(int ID)
        {
            var b = c.Yorumlars.Find(ID);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult YorumGetir(int ID)
        {
            var yr = c.Yorumlars.Find(ID);
            return View("YorumGetir", yr);

        }
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.Yorumlars.Find(y.ID);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("Yorumlistesi");

        }
        private Context _dbContext;

        public AdminController()
        {
            _dbContext = new Context();
        }

        public ActionResult İletisim()
        {
            List<İletisim> iletişimVerileri = _dbContext.İletisims.ToList();
            return View(iletişimVerileri);
        }
        public ActionResult İletisimSil(int id)
        {
            var iletişim = _dbContext.İletisims.Find(id);
            if (iletişim == null)
            {
                return RedirectToAction("Hata Sayfası"); 
            }

            _dbContext.İletisims.Remove(iletişim);
            _dbContext.SaveChanges();

            return RedirectToAction("İletisim");
        }
        
    }
}