using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik

        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var uyesayi = db.TBL_UYELER.Count();
            ViewBag.dgr = uyesayi;

            var kitapsayi = db.TBL_KITAP.Count();
            ViewBag.dgr2 = kitapsayi;

            var emanetkitap = db.TBL_KITAP.Where(x => x.DURUM == false).Count();
            ViewBag.dgr3 = emanetkitap;

            var kasadakipara = db.TBL_CEZALAR.Sum(x => x.PARA);
            ViewBag.dgr4 = kasadakipara;

            var kategorisayisi = db.TBL_KATEGORI.Count();
            ViewBag.dgr5 = kategorisayisi;

            var enfazlakitapyazar = db.EnFazlaKitapYazar().FirstOrDefault();
            ViewBag.dgr6 = enfazlakitapyazar;

            var enfazlaokunankitap = db.TBL_HAREKET.GroupBy(x => x.KITAP).OrderByDescending(x => x.Count()).Select(
                x =>  x.Key ).FirstOrDefault(); // key : gruplama sonucu gelecek değer
            var kitapAdi = db.TBL_KITAP.FirstOrDefault(k => k.ID == enfazlaokunankitap)?.AD;
            ViewBag.dgr7 = kitapAdi;

            var eniyipersonel = db.TBL_HAREKET.GroupBy(x => x.PERSONEL).OrderByDescending(x => x.Count()).Select(
               x => x.Key).FirstOrDefault(); 
            var personeladi = db.TBL_PERSONEL.FirstOrDefault(k => k.ID == eniyipersonel)?.PERSONEL;
            ViewBag.dgr8 = personeladi;

            var enaktifuye = db.TBL_HAREKET.GroupBy(x => x.UYE).OrderByDescending(x => x.Count()).Select(
               x => x.Key).FirstOrDefault(); 
            var uyeadi = db.TBL_UYELER.FirstOrDefault(k => k.ID == enaktifuye)?.AD;
            var uyesoyadi = db.TBL_UYELER.FirstOrDefault(k => k.ID == enaktifuye)?.SOYAD;

            ViewBag.dgr9 = uyeadi + " " + uyesoyadi;

            //var bugunkukıtap = db.TBL_HAREKET.Where(x => x.ALISTARIH == DateTime.Now).GroupBy(x => x.KITAP).OrderByDescending(x => x.Count()).Select(
            //   x => x.Key).FirstOrDefault(); 
            //var kitapAdi2 = db.TBL_KITAP.FirstOrDefault(k => k.ID == bugunkukıtap)?.AD;

            var bugunkukıtap = db.TBL_HAREKET.Count(x => x.ALISTARIH == DateTime.Today);

            //int kitapyok = 0;

            //if(bugunkukıtap == null)
            //{
            //    ViewBag.dgr10 = kitapyok;
            //}
            //else
            //{
                ViewBag.dgr10 = bugunkukıtap;
           // }
            


            //Bugünkü Ödünç Kitap Sayısı yapılacak..

            return View();
        }
        public ActionResult Galeri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase dosya)
        {
            if(dosya.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("/web2/resimler/"), Path.GetFileName
                    (dosya.FileName));

                dosya.SaveAs(dosyayolu);
            }
            return RedirectToAction("Galeri");
        }

    }
}