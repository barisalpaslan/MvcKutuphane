using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class YazarController : Controller
    {
        // GET: Yazar

        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        public ActionResult Index()
        {
            var degerler = db.TBL_YAZAR.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(TBL_YAZAR p)
        {
            if(!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.TBL_YAZAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarSil(int id)
        {
            var yazar = db.TBL_YAZAR.Find(id);
            db.TBL_YAZAR.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGetir(int id)
        {
            var yzr = db.TBL_YAZAR.Find(id);
            return View("YazarGetir", yzr);
        }
        public ActionResult YazarGuncelle(TBL_YAZAR p)
        {
            var yzr = db.TBL_YAZAR.Find(p.ID);
            // var yzr = db.TBL_YAZAR.FirstOrDefault(k => k.ID == p.ID);
            yzr.AD = p.AD;
            yzr.SOYAD = p.SOYAD;
            yzr.DETAY = p.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarKitaplar(int id)
        {
            var yazar = db.TBL_KITAP.Where(x => x.YAZAR == id).ToList();

            var yzrad = db.TBL_YAZAR.Where(x => x.ID == id).Select(x => x.AD + " " + x.SOYAD).FirstOrDefault();

            ViewBag.dgr = yzrad;

            return View(yazar); 
        }
    }
}