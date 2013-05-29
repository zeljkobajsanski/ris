using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Ris.Web.ViewModels;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.EntityFramework.Repositories;
using DevExpress.Web.Mvc;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using Rs.Dnevnik.Ris.Interfaces.Services;

namespace Ris.Web.Controllers
{
    public class AgencijskeVestiController : Controller
    {
        private readonly IRepositoryFactory fRepositoryFactory;

        private readonly ITextKonvertor fTextKonvertor;

        public AgencijskeVestiController(IRepositoryFactory repositoryFactory, ITextKonvertor textKonvertor)
        {
            fRepositoryFactory = repositoryFactory;
            fTextKonvertor = textKonvertor;
        }

        public ActionResult Index()
        {
            var vm = new AgencijskeVestiViewModel
            {
                Agencije = fRepositoryFactory.AgencijeRepository.VratiAgencije(),
                AgencijskeVesti = Enumerable.Empty<AgencijskaVest>(),
            };
            return View(vm);
        }


        [ValidateInput(false)]
        public ActionResult AgencijskeVestiGrid(DateTime? datum, int? idAgencije, string sadrzaj)
        {
            fRepositoryFactory.AgencijskeVestiRepository.AutoDetectChangesEnabled = false;
            var vesti = fRepositoryFactory.AgencijskeVestiRepository.PretraziVesti(datum, idAgencije,
                                                                                   KonvertujPretragu(sadrzaj));
            var vm = new AgencijskeVestiViewModel
            {
                Agencije = fRepositoryFactory.AgencijeRepository.VratiAgencije(),
                AgencijskeVesti = vesti,
                DefaultAgencija = idAgencije
            };
            return PartialView("_AgencijskeVestiGrid", vm);
        }

        public JsonResult PojmoviPretrage(string pojmoviPretrage)
        {
            var pojmovi = KonvertujPretragu(pojmoviPretrage).SelectMany(x => x.GetAll());
            return Json(pojmovi, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<PojamPretrage> KonvertujPretragu(string sadrzaj)
        {
            var pojmoviPretrage = (sadrzaj != null ? sadrzaj.Split(' ') : new string[0]);
            var sviPojmoviPretrage = new List<PojamPretrage>();
            foreach (var pojamPretrage in pojmoviPretrage)
            {
                var pojam = new PojamPretrage() {Pojam = pojamPretrage};
                sviPojmoviPretrage.Add(pojam);
                var konvertovan = fTextKonvertor.Konvertuj(pojamPretrage);
                if (!pojamPretrage.Equals(konvertovan))
                {
                    pojam.Aliasi.Add(konvertovan);
                }
            }
            return sviPojmoviPretrage;
        }

        public ActionResult VratiVest(int? id)
        {
            var vest = new AgencijskaVest();
            if (id.HasValue)
            {
                vest = fRepositoryFactory.AgencijskeVestiRepository.VratiPoId(id.Value);    
            }
            return Json(vest, JsonRequestBehavior.AllowGet);
        }
    }
}
