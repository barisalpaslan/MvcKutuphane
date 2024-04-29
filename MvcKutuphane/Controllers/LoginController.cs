using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBL_UYELER p)
        {
            var bilgiler = db.TBL_UYELER.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);

            if (bilgiler != null) 
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["Mail"] = bilgiler.MAIL.ToString();
                //TempData["ID"] = bilgiler.ID.ToString();
                //TempData["AD"] = bilgiler.AD.ToString();
                //TempData["SOYAD"] = bilgiler.SOYAD.ToString(); //Session içine yazılan veritabanındakiyle aynı olmak zorunda değil
                //TempData["KULLANICIADI"] = bilgiler.KULLANICIADI.ToString();
                //TempData["SIFRE"] = bilgiler.SIFRE.ToString();
                //TempData["OKUL"] = bilgiler.OKUL.ToString();

                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap");
        }
    }
}