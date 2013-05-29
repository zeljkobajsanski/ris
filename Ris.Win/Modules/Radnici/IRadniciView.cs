using System.ComponentModel;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.Win.Modules.Radnici
{
    public interface IRadniciView : IView
    {
        void FokusirajRadnika(Radnik radnik);
        void PrikaziRadnike(BindingList<Radnik> radnici);
    }
}