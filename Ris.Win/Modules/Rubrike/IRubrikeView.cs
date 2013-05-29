using System.ComponentModel;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.Win.Modules.Rubrike
{
    public interface IRubrikeView : IView
    {
        void PrikaziRubrike(BindingList<Rubrika> rubrike);
        void FokusirajRubriku(Rubrika rubrika);
    }
}