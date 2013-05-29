using System.ComponentModel;
using Rs.Dnevnik.Ris.Core.Model;
using System.Linq;

namespace Rs.Dnevnik.Ris.Win.Modules.Radnici
{
    public class RadniciPresenter : PresenterBase
    {
        private readonly IRadniciView fView;

        private BindingList<Radnik> fRadnici = new BindingList<Radnik>(); 

        public RadniciPresenter(IRadniciView fView)
        {
            this.fView = fView;
        }

        public override void OnLoad()
        {
            Osvezi();
        }

        public override void Novi()
        {
            var radnik = fRadnici.AddNew();
            fView.FokusirajRadnika(radnik);
        }

        public override bool Sacuvaj()
        {
            if (fRadnici.Any(x => !x.IsValid))
            {
                fView.UpozoriKorisnika("Ispravite sve greške");
                return false;
            }
            foreach (var radnik in fRadnici)
            {
                RepositoryFactory.RadniciRepository.Add(radnik);
            }
            RepositoryFactory.RadniciRepository.Save();
            return true;
        }

        public override void Osvezi()
        {
            fRadnici = new BindingList<Radnik>(RepositoryFactory.RadniciRepository.VratiRadnike().ToList());
            fView.PrikaziRadnike(fRadnici);
        }
    }
}