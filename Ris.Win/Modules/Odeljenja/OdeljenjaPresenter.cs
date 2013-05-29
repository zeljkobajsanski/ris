using System.ComponentModel;
using Rs.Dnevnik.Ris.Core.Model;
using System.Linq;

namespace Rs.Dnevnik.Ris.Win.Modules.Odeljenja
{
    public class OdeljenjaPresenter : PresenterBase
    {
        private readonly IOdeljenjaView fView;
        private int? fIdSektora;
        private readonly BindingList<Odeljenje> fOdeljenja = new BindingList<Odeljenje>(); 

        public OdeljenjaPresenter(IOdeljenjaView view)
        {
            fView = view;
            fView.PrikaziOdeljenja(fOdeljenja);
        }


        public int? IdSektora
        {
            get { return fIdSektora; }
            set
            {
                if (fIdSektora != value)
                {
                    fIdSektora = value;
                    UcitajOdeljenja();
                }
            }
        }

        private void UcitajOdeljenja()
        {
            if (!IdSektora.HasValue)
            {
                //fView.UpozoriKorisnika("Izaberite sektor");
                return;
            }
            fOdeljenja.Clear();
            var odeljenja = RepositoryFactory.OdeljenjaRepository.VratiOdeljenja(IdSektora.Value);
            foreach (var odeljenje in odeljenja)
            {
                fOdeljenja.Add(odeljenje);
            }
        }

        public override void Novi()
        {
            if (!IdSektora.HasValue)
            {
                fView.UpozoriKorisnika("Izaberite sektor");
                return;
            }
            var odeljenje = fOdeljenja.AddNew();
            odeljenje.SektorID = IdSektora;
            fView.FokusirajOdeljenje(odeljenje);
        }

        public override void Osvezi()
        {
            UcitajOdeljenja();
        }

        public override bool Sacuvaj()
        {
            if (fOdeljenja.Any(x => !x.IsValid))
            {
                fView.UpozoriKorisnika("Podaci nisu validni. Ispravite sve greške");
                return false;
            }
            foreach (var odeljenje in fOdeljenja)
            {
                RepositoryFactory.OdeljenjaRepository.Add(odeljenje);
            }
            RepositoryFactory.OdeljenjaRepository.Save();
            return true;
        } 
    }
}