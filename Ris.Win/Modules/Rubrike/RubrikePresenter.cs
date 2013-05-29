using System.ComponentModel;
using Rs.Dnevnik.Ris.Core.Model;
using System.Linq;

namespace Rs.Dnevnik.Ris.Win.Modules.Rubrike
{
    public class RubrikePresenter : PresenterBase
    {
        private readonly IRubrikeView fView;
        private int? fIdPublikacije;
        private readonly BindingList<Rubrika> fRubrike = new BindingList<Rubrika>(); 

        public int? IdPublikacije
        {
            get { return fIdPublikacije; }
            set
            {
                if (fIdPublikacije != value)
                {
                    fIdPublikacije = value;
                    UcitajRubrike();
                }
            }
        }

        public RubrikePresenter(IRubrikeView view)
        {
            fView = view;
            fView.PrikaziRubrike(fRubrike);
        }

        public override bool Sacuvaj()
        {
            if (fRubrike.Any(x => !x.IsValid))
            {
                fView.UpozoriKorisnika("Ispravite greške");
                return false;
            }
            foreach (var rubrika in fRubrike)
            {
                RepositoryFactory.RubrikeRepository.Add(rubrika);
            }
            RepositoryFactory.RubrikeRepository.Save();
            return true;
        }

        public override void Osvezi()
        {
            base.Osvezi();
            UcitajRubrike();
        }

        public override void Novi()
        {
           KreirajNovu();
        }

        public void KreirajNovu()
        {
            if (!IdPublikacije.HasValue)
            {
                fView.UpozoriKorisnika("Izaberite publikaciju");
                return;
            }
            var rubrika = fRubrike.AddNew();
            rubrika.PublikacijaID = IdPublikacije;
            fView.FokusirajRubriku(rubrika);
        }

        private void UcitajRubrike()
        {
            if (IdPublikacije.HasValue)
            {
                fRubrike.Clear();
                var rubrike = RepositoryFactory.RubrikeRepository.VratiRubrike(IdPublikacije.Value).OrderBy(x => x.Sort);
                foreach (var rubrika in rubrike)
                {
                    fRubrike.Add(rubrika);
                }
            }
        }
    }
}