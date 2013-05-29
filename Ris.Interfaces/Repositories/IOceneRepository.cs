using System.Collections.Generic;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.Interfaces.Repositories
{
    public interface IOceneRepository : IRepository
    {
        ICollection<Ocena> Ocene();
    }
}