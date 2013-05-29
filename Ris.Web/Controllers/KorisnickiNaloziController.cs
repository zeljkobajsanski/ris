using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using DevExpress.Web.Mvc;
using Ris.Web.Infrastructure;
using Ris.Web.Utils.Message;
using Ris.Web.ViewModels;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Core.Utils;
using Rs.Dnevnik.Ris.Interfaces.Repositories;

namespace Ris.Web.Controllers
{
    [HandleError]
    public class KorisnickiNaloziController : Controller
    {
        private readonly IRepositoryFactory fRepositoryFactory;

        public KorisnickiNaloziController(IRepositoryFactory fRepositoryFactory)
        {
            this.fRepositoryFactory = fRepositoryFactory;
        }

        [SessionRequired(Roles = "Admin")]
        public ActionResult Index()
        {
            var vm = new KorisnickiNaloziViewModel
            {
                KorisnickiNalozi = fRepositoryFactory.KorisnickiNaloziRepository.VratiKorisnickeNaloge(),
                Radnici = fRepositoryFactory.RadniciRepository.VratiRadnike(),
                Uloge = fRepositoryFactory.UlogeRadnikaRepository.VratiUloge()
            };
            if (Request.IsAjaxRequest())
            {
                return PartialView("_KorisnickiNaloziGrid", vm);
            }
            return View(vm);
        }

        public void Sacuvaj(KorisnickiNalog korisnickiNalog)
        {
            var izabraneUloge = CheckBoxListExtension.GetSelectedValues<int>("UlogeRadnika");
            var zaSnimanje = fRepositoryFactory.KorisnickiNaloziRepository.VratiKorisnickiNalog(korisnickiNalog.ID) ??
                             new KorisnickiNalog();
            zaSnimanje.KorisnickoIme = korisnickiNalog.KorisnickoIme;
            if (!String.IsNullOrEmpty(korisnickiNalog.LozinkaPlain))
            {
                zaSnimanje.LozinkaPlain = korisnickiNalog.LozinkaPlain;
                zaSnimanje.Lozinka = HashUtilities.CalculateMd5Hash(korisnickiNalog.LozinkaPlain);
            }
            else
            {
                zaSnimanje.LozinkaPlain = "Stavljeno samo zbog validacije";
            }
            zaSnimanje.RadnikID = korisnickiNalog.RadnikID;
            fRepositoryFactory.KorisnickiNaloziRepository.Add(zaSnimanje);
            if (korisnickiNalog.ID == 0)
            {
                fRepositoryFactory.KorisnickiNaloziRepository.Save();
                return;
            }

            var sveUloge = fRepositoryFactory.UlogeRadnikaRepository.VratiUloge();
            var sacuvaneUloge = zaSnimanje.Radnik.UlogeRadnika.ToArray();
            foreach (var uloga in sacuvaneUloge)
            {
                if (izabraneUloge.All(x => x != uloga.ID))
                {
                    var ulogaZaBrisanje = sacuvaneUloge.Single(x => x.ID == uloga.ID);
                    zaSnimanje.Radnik.UlogeRadnika.Remove(ulogaZaBrisanje);
                }
            }
            foreach (var id in izabraneUloge)
            {
                var uloga = sveUloge.Single(x => x.ID == id);
                zaSnimanje.Radnik.UlogeRadnika.Add(uloga);
            }
            fRepositoryFactory.KorisnickiNaloziRepository.Save();
        }

        public ActionResult UcitajUlogeKorisnika(int id)
        {
            var uloge = fRepositoryFactory.KorisnickiNaloziRepository.VratiKorisnikaSaUlogama(id).Radnik.UlogeRadnika.ToArray();
            return Json(uloge, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RadniciComboBox(int? idRadnika)
        {
            var model = new RadniciComboBox()
            {
                Name = "KorisnickiNalog.RadnikID",
                IzabraniRadnik = idRadnika,
                Radnici = fRepositoryFactory.RadniciRepository.VratiRadnike()
            };
            return PartialView("RadniciComboBox", model);
        }

        public ActionResult VratiKorisnickiNalog(int? id)
        {
            var model = new KorisnickiNaloziViewModel
                            {
                                KorisnickiNalog =  id.HasValue ? fRepositoryFactory.KorisnickiNaloziRepository.VratiKorisnickiNalog(id.Value) 
                                                               : new KorisnickiNalog(){Radnik = new Radnik()},
                                Uloge = fRepositoryFactory.UlogeRadnikaRepository.VratiUloge()
                            };
            return PartialView("_KorisnickiNalogCallbackPanel", model);
        }
    }
}
