using System.Collections.Generic;
using System.Linq;
using Rs.Dnevnik.Ris.Core.Model;

namespace Ris.Web.ViewModels
{
    public class UnosTekstaViewModel
    {
        public UnosTekstaViewModel()
        {
            Tekst = new Tekst();
            Publikacije = Enumerable.Empty<Publikacija>();
            TipoviTeksta = Enumerable.Empty<TipTeksta>();
        }

        public Tekst Tekst { get; set; }
        public IEnumerable<Publikacija> Publikacije { get; set; }
        public IEnumerable<TipTeksta> TipoviTeksta { get; set; }
        public bool SaljiNovinaru { get; set; }
        public bool SaljiUredniku { get; set; }
        public bool SaljiLektoru { get; set; }
        public bool SaljiUDTP { get; set; }
        public bool ReadOnly { get; set; }
    }
}