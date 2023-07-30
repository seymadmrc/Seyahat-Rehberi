using Seyahat_Rehberi.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seyahat_Rehberi.Controllers
{
    public class İletisimController : Controller
    {
        // GET: İletisim
        Context c = new Context();

        [HttpPost]
        public PartialViewResult Mesaj(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }

        
    private Context _dbContext;

        public İletisimController()
        {
            _dbContext = new Context();
        }

        public ActionResult Index()
        {
            return View(); 
            
        }
        
        public ActionResult ThankYou()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(İletisim model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.İletisims.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("ThankYou"); 
            }

            return View(model);
        }

    }
}


