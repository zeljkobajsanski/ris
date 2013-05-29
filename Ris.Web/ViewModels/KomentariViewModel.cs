using System.Collections.Generic;
using System.Linq;
using Rs.Dnevnik.Ris.Core.Model;

namespace Ris.Web.ViewModels
{
    public class KomentariViewModel
    {
        public KomentariViewModel()
        {
            Komentar = new Komentar();
            RanijiKomentari = Enumerable.Empty<Komentar>();
        }

        public int? IdTeksta { get; set; }
        public Komentar Komentar { get; set; }
        public IEnumerable<Komentar> RanijiKomentari { get; set; }
    }
}