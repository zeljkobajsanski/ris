using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ris.Web.ViewModels;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;

namespace Ris.Web.Controllers
{
    public class RadniListController : Controller
    {
        private readonly IRepositoryFactory fRepositoryFactory;

        public RadniListController(IRepositoryFactory repositoryFactory)
        {
            fRepositoryFactory = repositoryFactory;
        }

        [HttpGet]
        public ActionResult Index(RadniListViewModel model)
        {
            if (!model.Publikacija.HasValue || !model.Datum.HasValue)
            {
                return View(new RadniListViewModel()
                {
                    PublikacijeLookup = fRepositoryFactory.PublikacijeRepository.Publikacije(),
                });
            }
            var vm = new RadniListViewModel()
            {
                PublikacijeLookup = fRepositoryFactory.PublikacijeRepository.Publikacije(),
                Datum = model.Datum,
                Publikacija = model.Publikacija,
                TipoviTeksta = fRepositoryFactory.TipoviTekstovaRepository.TipoviTekstova(),
                Rubrike = fRepositoryFactory.RubrikeRepository.VratiRubrike(model.Publikacija),
                Radnici = fRepositoryFactory.RadniciRepository.VratiRadnike()
            };
            vm.RadniNalozi = VratiRadneNaloge(model.Publikacija.Value, model.Datum.Value);
            
            return View(vm);
        }

        public PartialViewResult RadniListPartial(int? idPublikacije, DateTime? datum)
        {
            if (!idPublikacije.HasValue || !datum.HasValue)
            {
                return PartialView("_RadniNaloziGrid", new RadniListViewModel());
            }
            var rn = VratiRadneNaloge(idPublikacije.Value, datum.Value);
            return PartialView("_RadniNaloziGrid", new RadniListViewModel(){RadniNalozi = rn});
        }

        private List<RadniNalog> VratiRadneNaloge(int idPublikacije, DateTime datum)
        {
            var l = fRepositoryFactory.RadniNaloziRepository.VratiRadneNaloge(idPublikacije, datum).ToList();
            var radnici = fRepositoryFactory.RadniciRepository.VratiRadnikePoRubrikama();
            foreach (var radnik in radnici)
            {
                if (l.All(x => x.RadnikID != radnik.ID))
                {
                    l.Add(new RadniListNovinara()
                    {
                        ID = l.Any() ? l.Min(x => x.ID) - 1 : 0,
                        Datum = datum,
                        PublikacijaID = idPublikacije,
                        RadnikID = radnik.ID,
                        //TipAktivnosti = "NT"
                        
                    });
                }
            }
            return l;
        }
    }
}
