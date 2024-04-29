using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc

        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        public ActionResult Index()
        {
            var degerler = db.TBL_HAREKET.Where(x => x.ISLEMDURUM == false).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> uye = (from i in db.TBL_UYELER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + " " + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = uye;

            List<SelectListItem> kitap = (from i in db.TBL_KITAP.Where(x => x.DURUM == true).ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.AD,
                                            Value = i.ID.ToString()
                                        }).ToList();
            ViewBag.dgr2 = kitap;

            List<SelectListItem> personel = (from i in db.TBL_PERSONEL.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.PERSONEL,
                                              Value = i.ID.ToString()
                                          }).ToList();
            ViewBag.dgr3 = personel;

            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TBL_HAREKET p)
        {
            var uye = db.TBL_UYELER.Where(x => x.ID == p.TBL_UYELER.ID).FirstOrDefault();
            var kitap = db.TBL_KITAP.Where(x => x.ID == p.TBL_KITAP.ID).FirstOrDefault();
            var personel = db.TBL_PERSONEL.Where(x => x.ID == p.TBL_PERSONEL.ID).FirstOrDefault();

            p.TBL_UYELER = uye;
            p.TBL_KITAP = kitap;
            p.TBL_PERSONEL = personel;


            db.TBL_HAREKET.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OduncIade(TBL_HAREKET p)
        {
            var odn = db.TBL_HAREKET.Find(p.ID);

            DateTime d1 = DateTime.Parse(odn.IADETARIH.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            
            ViewBag.dgr = d3.TotalDays;

            return View("OduncIade", odn);
        }
        public ActionResult OduncGuncelle(TBL_HAREKET p)
        {
            var hrk = db.TBL_HAREKET.Find(p.ID);
            hrk.UYEGETIRTARIH = p.UYEGETIRTARIH;
            hrk.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}