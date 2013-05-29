using System;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Core.Utils;
using Rs.Dnevnik.Ris.Win.Alerts;
using System.Linq;

namespace Rs.Dnevnik.Ris.Win.Modules.IzvestajRadnihNalog
{
    public class IzvestajPoDatumuPresenter : PresenterBase
    {
        private readonly IIzvestajPoDatumuView fView;

        private DateTime fOdDatuma;
        private DateTime fDoDatuma;

        public IzvestajPoDatumuPresenter(IIzvestajPoDatumuView view)
        {
            fView = view;
        }

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

        public override void OnLoad()
        {
            OdDatuma = DateUtilities.GetStartOfCurrentMonth();
            DoDatuma = DateUtilities.GetEndOfCurrentMonth();
        }

        public void Prikazi(int? idRadnika)
        {
            if (!idRadnika.HasValue)
            {
                fView.ObavestiKorisnika("Izaberite radnika");
                return;
            }
            var tipviTekstova = RepositoryFactory.TipoviTekstovaRepository.TipoviTekstova();
            var izvestaj = RepositoryFactory.RadniNaloziRepository.VratiIzvestajPoDatumu(idRadnika.Value, OdDatuma, DoDatuma);
            
            
            var brojDana = DoDatuma.Subtract(OdDatuma).Days + 1;
            for (var i = 0; i < brojDana; i++)
            {
                var datum = OdDatuma.Add(TimeSpan.FromDays(i));
                foreach (var tipTeksta in tipviTekstova)
                {
                    if (izvestaj.Any(x => x.Datum == datum && x.TipTekstaID == tipTeksta.ID)) continue;
                    izvestaj.Add(new OstvarenjejRadnogNaloga
                                     {
                                         Datum = datum, 
                                         TipTekstaID = tipTeksta.ID, 
                                         TipTeksta = tipTeksta.Naziv
                                     });
                }
            }
            fView.PrikaziIzvestaj(izvestaj);
        }
    }
}