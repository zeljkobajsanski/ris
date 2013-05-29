using System.Collections.Generic;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.Interfaces.Repositories
{
    public interface IKonverzijaRepository : IRepository
    {
        IEnumerable<Konverzija> VratiSabloneKonverzije();
    }
}