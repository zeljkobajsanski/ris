using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;

namespace Ris.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserInfo()
        {
            if (!HttpContext.Request.IsAuthenticated || HttpContext.Session == null)
            {
                ViewBag.UserName = "Anoniman korisnik";
                return PartialView("User");
            }
            var session = HttpContext.Session["Korisnik"];
            var korisnik = session as KorisnickiNalog;
            ViewBag.UserName = korisnik != null ? korisnik.Radnik.ImeIPrezime : "Anoniman korisnik";
            ViewBag.UserID = korisnik != null ? korisnik.ID : (int?)null;
            if (korisnik != null)
            {
                var brojUloga = korisnik.Radnik.UlogeRadnika.Count;
                if (brojUloga > 0)
                {
                    ViewBag.UserName += " (" + korisnik.Radnik.UlogeRadnika.First().Naziv;
                    if (brojUloga > 1)
                    {
                        ViewBag.UserName += "+)";
                    }
                    else
                    {
                        ViewBag.UserName += ")";
                    }
                }
            }
            return PartialView("User");
        }

    }
}
