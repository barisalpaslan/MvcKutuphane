using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class PersonelController : Controller
    {
        // GET: Personel

        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        public ActionResult Index()
        {
            var degerler = db.TBL_PERSONEL.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(TBL_PERSONEL p)
        {
            if(!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }

            db.TBL_PERSONEL.Add(p);
            db.SaveChanges();
            //  return View();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var personel = db.TBL_PERSONEL.Find(id);
            db.TBL_PERSONEL.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            var prs = db.TBL_PERSONEL.Find(id);
            return View("PersonelGetir", prs);
        }
        public ActionResult PersonelGuncelle(TBL_PERSONEL p)
        {
            //var ktg = db.TBL_KATEGORI.Find(p.ID);
            var prs = db.TBL_PERSONEL.FirstOrDefault(k => k.ID == p.ID);
            prs.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}