using Microsoft.Ajax.Utilities;
using Seyahat_Rehberi.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Context = Seyahat_Rehberi.Models.Sınıflar.Context;

namespace Seyahat_Rehberi.Controllers
{
    public class GirişYapController : Controller
    {
        // GET: GirişYap

        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin ad) 
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.Kullanici == ad.Kullanici && x.Sifre == ad.Sifre);
                if (bilgiler != null)
                {
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
                Session["Kullanici"] = bilgiler.Kullanici.ToString();
                return RedirectToAction("Index","Admin");
                }
                else 
                { 
                return View();
                }      
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","GirişYap");
        }
    }
}