using System.Collections.Generic;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.Interfaces.Repositories
{
    public interface IKorisnickiNaloziRepository : IRepository
    {
        KorisnickiNalog VratiKorisnickiNalog(string korisnickoIme, string lozinka);
        KorisnickiNalog VratiKorisnikaSaUlogama(int idKorisnika);
        IEnumerable<KorisnickiNalog> VratiKorisnickeNaloge();
        KorisnickiNalog VratiKorisnickiNalog(int id);
    }
}