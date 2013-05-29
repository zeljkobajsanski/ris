using System.Collections.Generic;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.Interfaces.Repositories
{
    public interface IAgencijeRepository : IRepository
    {
        ICollection<Agencija> VratiAgencije();
        Agencija VratiAgencijuSaEmailom(string email);
    }
}