using System;
using System.Collections.Generic;
using System.Data;
using Rs.Dnevnik.Ris.Core.Exceptions;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Core.Utils;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using System.Linq;

namespace Rs.Dnevnik.Ris.EntityFramework.Repositories
{
    public class KorisnickiNaloziRepository : RepositoryBase, IKorisnickiNaloziRepository
    {
        public KorisnickiNaloziRepository()
        {
        }

        public KorisnickiNaloziRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public override void Add<T>(T entity)
        {
            var kn = entity as KorisnickiNalog;
            if (kn != null && DataContext.Entry(kn).State == EntityState.Detached)
            {
                DataContext.KorisnickiNalozi.Add(kn);
            }
        }

        public KorisnickiNalog VratiKorisnickiNalog(string korisnickoIme, string lozinka)
        {
            if (korisnickoIme == null) throw new LoginException("Korisničko ime nije uneto");
            if (lozinka == null) throw new LoginException("Lozinka nije uneta");
            var korisnik = DataContext.KorisnickiNalozi.SingleOrDefault(x => x.KorisnickoIme == korisnickoIme);
            if (korisnik == null)
            {
                throw new LoginException("Korisničko ime nije pronađeno");
            }
            var hash = HashUtilities.CalculateMd5Hash(lozinka);
            var okLozinka = korisnik.Lozinka.SequenceEqual(hash);
            if (!okLozinka) throw new LoginException("Lozinka se ne poklapa");
            return korisnik;
        }

        public KorisnickiNalog VratiKorisnikaSaUlogama(int idKorisnika)
        {
            return
                DataContext.KorisnickiNalozi.Include("Radnik")
                           .Include("Radnik.UlogeRadnika")
                           .SingleOrDefault(x => x.ID == idKorisnika);
        }

        public IEnumerable<KorisnickiNalog> VratiKorisnickeNaloge()
        {
            return DataContext.KorisnickiNalozi.ToArray();
        }

        public KorisnickiNalog VratiKorisnickiNalog(int id)
        {
            return DataContext.KorisnickiNalozi.Include("Radnik").Include("Radnik.UlogeRadnika").SingleOrDefault(x => x.ID == id);
        }
    }
}