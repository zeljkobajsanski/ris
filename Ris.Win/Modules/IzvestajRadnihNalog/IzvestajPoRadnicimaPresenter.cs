using System;
using System.Linq;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Core.Utils;

namespace Rs.Dnevnik.Ris.Win.Modules.IzvestajRadnihNalog
{
    public class IzvestajPoRadnicimaPresenter : PresenterBase
    {
        private readonly IIzvestajPoRadnicimaView fView;
        private DateTime fOdDatuma;
        private DateTime fDoDatuma;

        public DateTime OdDatuma
        {
            get { return fOdDatuma; }
            set
            {
                if (OdDatuma == value) return;
                fOdDatuma = value.Date;
                fView.PostaviOdDatuma(OdDatuma);
            }
        }

        public DateTime DoDatuma
        {
            get { return fDoDatuma; }
            set
            {
                if (DoDatuma == value) return;
                fDoDatuma = value.Date;
                fView.PostaviDoDatuma(DoDatuma);
            }
        }

        public int? IdPublikacije { get; set; }

        public IzvestajPoRadnicimaPresenter(IIzvestajPoRadnicimaView view)
        {
            fView = view;
        }

        public override void OnLoad()
        {
            OdDatuma = DateUtilities.GetStartOfCurrentMonth();
            DoDatuma = DateUtilities.GetEndOfCurrentMonth();
        }

        public void Prikazi()
        {
            if (!IdPublikacije.HasValue)
            {
                fView.ObavestiKorisnika("Izaberite publikaciju");
                return;
            }
            var tipoviTekstova = RepositoryFactory.TipoviTekstovaRepository.TipoviTekstova();
            var izvestaj = RepositoryFactory.RadniNaloziRepository.VratiIzvestajPoRadnicima(IdPublikacije.Value, OdDatuma, DoDatuma);
            var radnici = RepositoryFactory.RadniciRepository.VratiRadnike();

            foreach (var radnik in radnici)
            {
                foreach (var tipTeksta in tipoviTekstova)
                {
                    if (izvestaj.Any(x => x.RadnikID == radnik.ID && x.TipTekstaID == tipTeksta.ID)) continue;
                    izvestaj.Add(new OstvarenjejRadnogNaloga{Radnik = radnik.ImeIPrezime, TipTeksta = tipTeksta.Naziv});
                }
            }
            
            fView.PrikaziIzvestaj(izvestaj);
        }
    }
}