using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Rs.Dnevnik.Ris.Core.Exceptions;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Core.Utils;
using Rs.Dnevnik.Ris.Interfaces.Repositories;

namespace Ris.Web.Controllers
{
    public class PrijavaController : Controller
    {
        private readonly IRepositoryFactory fRepositoryFactory;

        public PrijavaController(IRepositoryFactory repositoryFactory)
        {
            fRepositoryFactory = repositoryFactory;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new KorisnickiNalog());
            return Index(new KorisnickiNalog() {KorisnickoIme = "admin", LozinkaPlain = "admin"}, null);
        }

        [HttpPost]
        public ActionResult Index(KorisnickiNalog korisnickiNalog, string returnUrl)
        {
            if (korisnickiNalog.LozinkaPlain != null)
            {
                korisnickiNalog.Lozinka = HashUtilities.CalculateMd5Hash(korisnickiNalog.LozinkaPlain);
            }
            if (!korisnickiNalog.IsValid)
            {
                return View(korisnickiNalog);
            }
            try
            {
                var nalog = fRepositoryFactory.KorisnickiNaloziRepository.VratiKorisnickiNalog(korisnickiNalog.KorisnickoIme,
                                                                                       korisnickiNalog.LozinkaPlain);
                var cookie = FormsAuthentication.GetAuthCookie(korisnickiNalog.KorisnickoIme, false);
                var ticket = new FormsAuthenticationTicket(1, korisnickiNalog.KorisnickoIme, DateTime.Now, DateTime.Now.AddMonths(6),
                                                           false, nalog.ID.ToString());

                cookie.Value = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(cookie);
                var korisnik = fRepositoryFactory.KorisnickiNaloziRepository.VratiKorisnikaSaUlogama(nalog.ID);
                Session.Add("Korisnik", korisnik);
                if (string.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                return  Redirect(returnUrl);
            }
            catch (LoginException le)
            {
                ViewBag.Error = le.Message;
                return View(korisnickiNalog);
            }
            
        }

        public ActionResult OdjaviMe()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

    }
}
