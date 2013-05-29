using System.Collections.Generic;
using System.Linq;
using Rs.Dnevnik.Ris.Core.Model;

namespace Ris.Web.ViewModels
{
    public class PretragaFotoArhiveViewModel
    {
        public PretragaFotoArhiveViewModel()
        {
            Publikacije = Enumerable.Empty<Publikacija>();
            GrupeMaterijala = Enumerable.Empty<GrupaMaterijala>();
        }

        public IEnumerable<Publikacija> Publikacije { get; set; }
        public IEnumerable<GrupaMaterijala> GrupeMaterijala { get; set; }
    }
}