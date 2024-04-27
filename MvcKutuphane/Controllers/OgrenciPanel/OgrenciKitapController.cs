using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers.OgrenciPanel
{
    public class OgrenciKitapController : Controller
    {
        // GET: OgrenciKitap
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var id = db.TBL_UYELER.Where(x => x.MAIL ==  uyemail.ToString()).Select(x => x.ID).FirstOrDefault();
            var degerler = db.TBL_HAREKET.Where(x => x.ISLEMDURUM == true && x.UYE == id).ToList();
            return View(degerler);
        }
    }
}