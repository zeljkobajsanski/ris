using System.Collections.Generic;
using System.Linq;
using Rs.Dnevnik.Ris.Core.Model;

namespace Ris.Web.ViewModels
{
    public class KorisnickiNaloziViewModel
    {
        public KorisnickiNaloziViewModel()
        {
            KorisnickiNalozi = Enumerable.Empty<KorisnickiNalog>();
            Radnici = Enumerable.Empty<Radnik>();
            Uloge = Enumerable.Empty<UlogaRadnika>();
            KorisnickiNalog = new KorisnickiNalog(){Radnik = new Radnik()};
        }

        public IEnumerable<KorisnickiNalog> KorisnickiNalozi { get; set; }
        public IEnumerable<Radnik> Radnici { get; set; }
        public IEnumerable<UlogaRadnika> Uloge { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }
    }
}