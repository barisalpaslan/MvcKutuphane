using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        [HttpGet]
        public ActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KayitOl(TBL_UYELER p)
        {
            if(!ModelState.IsValid) 
            {
                return View("Register");
            }
            db.TBL_UYELER.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}