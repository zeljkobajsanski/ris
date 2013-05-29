using System.ComponentModel;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.Win.Modules.Odeljenja
{
    public interface IOdeljenjaView : IView
    {
        void PrikaziOdeljenja(BindingList<Odeljenje> odeljenja);
        void FokusirajOdeljenje(Odeljenje odeljenje);
    }
}