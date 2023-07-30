using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Seyahat_Rehberi.Models.Sınıflar;
using PagedList;
using PagedList.Mvc;
using System.Drawing.Printing;


namespace Seyahat_Rehberi.Controllers
{
    public class BlogController : Controller


    {
        // GET: Blog
        Context c = new Context();
        BlogYorum by = new BlogYorum();



        public ActionResult Index()
        {
            //var bloglar = c.Blogs.ToList();
            by.Deger1 = c.Blogs.ToList();
            by.Deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(by);
        }

        public ActionResult BlogDetay(int ID)
        {
            //var blogbul = c.Blogs.Where(x=>x.ID == ID).ToList();
            by.Deger1 = c.Blogs.Where(x => x.ID == ID).ToList();
            by.Deger2 = c.Yorumlars.Where(x => x.Blogid == ID).ToList();
            return View(by);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int ID)
        {
            ViewBag.deger = ID;
            return PartialView();
        }


        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            if (ModelState.IsValid)
            {
                c.Yorumlars.Add(y);
                c.SaveChanges();
            }
            return PartialView();
        }


    }
}