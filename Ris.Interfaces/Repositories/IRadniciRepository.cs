using System.Collections.Generic;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.Interfaces.Repositories
{
    public interface IRadniciRepository : IRepository
    {
        ICollection<Radnik> VratiRadnikeOdeljenja(int idOdeljenja);

        ICollection<Radnik> VratiRadnikeSektory(int idSektora);

        ICollection<Radnik> VratiRadnikeNovinskeKuce(int idNovinskeKuce);
        
        ICollection<Radnik> VratiRadnike();

        ICollection<Radnik> VratiRadnikePoRubrikama();

        Radnik VratiRadnikaSaUlogama(int idRadnika);
    }
}