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
        public ActionResult KayitOl()
        {
            return View();
        }
    }
}