using System;
using System.Collections.Generic;
using System.Linq;
using Rs.Dnevnik.Ris.Core.Model;

namespace Ris.Web.ViewModels
{
    public class RadniListViewModel
    {
        public RadniListViewModel()
        {
            Datum = DateTime.Now.Date;
            RadniNalozi = new List<RadniNalog>();
            RadniListNovinara = new RadniListNovinara();
            Rubrike = Enumerable.Empty<Rubrika>();
            TipoviTeksta = Enumerable.Empty<TipTeksta>();
            Radnici = Enumerable.Empty<Radnik>();
        }

        public int? Publikacija { get; set; }
        public DateTime? Datum { get; set; }
        public IEnumerable<Publikacija> PublikacijeLookup { get; set; }
        public IList<RadniNalog> RadniNalozi { get; set; }
        public RadniListNovinara RadniListNovinara { get; set; }
        public IEnumerable<TipTeksta> TipoviTeksta { get; set; }
        public IEnumerable<Rubrika> Rubrike { get; set; }
        public IEnumerable<Radnik> Radnici { get; set; }
    }
}