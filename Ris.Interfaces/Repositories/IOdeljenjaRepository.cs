using System.Collections.Generic;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.Interfaces.Repositories
{
    public interface IOdeljenjaRepository : IRepository
    {
        ICollection<Odeljenje> VratiOdeljenja(int idSektora);
        ICollection<Odeljenje> VratiOdeljenja();
    }
}