using MvcKutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class UyeController : Controller
    {
        // GET: Uye

        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        public ActionResult Index(int sayfa = 1)
        {
            //var degerler = db.TBL_UYELER.ToList();

            var degerler = db.TBL_UYELER.ToList().ToPagedList(sayfa, 3);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(TBL_UYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }

            db.TBL_UYELER.Add(p);
            db.SaveChanges();
            //  return View();
            return RedirectToAction("Index");
        }
        public ActionResult UyeSil(int id)
        {
            var uyeler = db.TBL_UYELER.Find(id);
            db.TBL_UYELER.Remove(uyeler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var prs = db.TBL_UYELER.Find(id);
            return View("UyeGetir", prs);
        }
        public ActionResult UyeGuncelle(TBL_UYELER p)
        {
            //var ktg = db.TBL_KATEGORI.Find(p.ID);
            var prs = db.TBL_UYELER.FirstOrDefault(k => k.ID == p.ID);
            prs.AD = p.AD;
            prs.SOYAD = p.SOYAD;
            prs.MAIL = p.MAIL;
            prs.KULLANICIADI = p.KULLANICIADI;
            prs.SIFRE = p.SIFRE;
            prs.FOTOGRAF = p.FOTOGRAF;
            prs.TELEFON = p.TELEFON;
            prs.OKUL = p.OKUL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeKitapGecmis(int id)
        {
            var ktpgecms = db.TBL_HAREKET.Where(x => x.UYE == id).ToList();

            var uyead = db.TBL_UYELER.Where(x => x.ID == id).Select(x => x.AD + " " + x.SOYAD).FirstOrDefault();

            ViewBag.dgr = uyead;

            return View(ktpgecms);
        }
    }
}