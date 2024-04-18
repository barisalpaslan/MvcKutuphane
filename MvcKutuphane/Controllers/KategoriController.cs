using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        public ActionResult Index()
        {
            var degerler = db.TBL_KATEGORI.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(TBL_KATEGORI p)
        {
            db.TBL_KATEGORI.Add(p);
            db.SaveChanges();
          //  return View();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBL_KATEGORI.Find(id);
            db.TBL_KATEGORI.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //veriyi id'sine göre çekiyoruz/çağırıyoruz
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TBL_KATEGORI.Find(id);
            return View("KategoriGetir", ktg);
        }
        //kullanıcıdan gelen veriyi aldığımız için "p"
        public ActionResult KategoriGuncelle(TBL_KATEGORI p)
        {
            //var ktg = db.TBL_KATEGORI.Find(p.ID);
            var ktg = db.TBL_KATEGORI.FirstOrDefault(k => k.ID == p.ID); 
            ktg.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}