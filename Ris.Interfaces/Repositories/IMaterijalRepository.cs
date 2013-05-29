using System.Collections.Generic;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.Interfaces.Repositories
{
    public interface IMaterijalRepository : IRepository
    {
        IEnumerable<Materijal> VratiSveMaterijale(string naziv);
        IEnumerable<Materijal> VratiSveMaterijale();
        IEnumerable<Materijal> Pretrazi(string naziv, string tag, int? idPublikacije, int? idGrupeMaterijala); 
        Materijal VratiMaterijal(int id);
    }
}