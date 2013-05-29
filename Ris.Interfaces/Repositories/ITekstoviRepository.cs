using System;
using System.Collections.Generic;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.Interfaces.Repositories
{
    public interface ITekstoviRepository : IRepository
    {
        Tekst VratiTekst(int id);
        IEnumerable<Tekst> VratiTekstoveZaUlogu(int? idPublikacije, int? idRubrike, DateTime? datum, int uloga);
        IEnumerable<Tekst> VratiTekstoveAutora(int? idPublikacije, int? idRubrike, DateTime? datum, int idRadnika, int uloga);
        IEnumerable<Komentar> VratiKomentare(int? idTeksta);
    }
}