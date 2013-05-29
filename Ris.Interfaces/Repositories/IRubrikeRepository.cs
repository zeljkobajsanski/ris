using System.Collections.Generic;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.Interfaces.Repositories
{
    public interface IRubrikeRepository : IRepository
    {
        ICollection<Rubrika> VratiRubrike(int? idPublikacije);
        ICollection<Rubrika> VratiSveRubrike();

    }
}