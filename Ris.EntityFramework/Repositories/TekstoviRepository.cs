using System;
using System.Collections.Generic;
using System.Data;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using System.Linq;

namespace Rs.Dnevnik.Ris.EntityFramework.Repositories
{
    public class TekstoviRepository : RepositoryBase, ITekstoviRepository
    {
        public TekstoviRepository()
        {
        }

        public TekstoviRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public override void Add<T>(T entity)
        {
            var tekst = entity as Tekst;
            if (tekst != null && DataContext.Entry(entity).State == EntityState.Detached)
            {
                DataContext.Tekstovi.Add(tekst);
            }
        }

        public Tekst VratiTekst(int id)
        {
            var tekst = DataContext.Tekstovi.Include("Materijali").Single(x => x.ID == id);
            var brojKomentara = DataContext.Tekstovi.Include("Komentari").Single(x => x.ID == id).Komentari.Count;
            tekst.BrojKomentara = brojKomentara;
            return tekst;
        }

        public IEnumerable<Tekst> VratiTekstoveZaUlogu(int? idPublikacije, int? idRubrike, DateTime? datum, int uloga)
        {
            var tekstovi = DataContext.Tekstovi.Where(x => x.TrenutnoKodID == uloga);
            if (idPublikacije.HasValue)
            {
                tekstovi = tekstovi.Where(x => x.PublikacijaID == idPublikacije);
            }
            if (idRubrike.HasValue)
            {
                tekstovi = tekstovi.Where(x => x.RubrikaID == idRubrike);
            }
            if (datum.HasValue)
            {
                var odDatuma = datum.Value.Date;
                var doDatuma = odDatuma.AddDays(1);
                tekstovi = tekstovi.Where(x => odDatuma <= x.Datum && x.Datum <= doDatuma);
            }
            return tekstovi.ToArray();
        }

        public IEnumerable<Tekst> VratiTekstoveAutora(int? idPublikacije, int? idRubrike, DateTime? datum, int idRadnika, int uloga)
        {
            var tekstovi = DataContext.Tekstovi.Where(x => x.AutorID == idRadnika && x.TrenutnoKodID == uloga);
            if (idPublikacije.HasValue)
            {
                tekstovi = tekstovi.Where(x => x.PublikacijaID == idPublikacije);
            }
            if (idRubrike.HasValue)
            {
                tekstovi = tekstovi.Where(x => x.RubrikaID == idRubrike);
            }
            if (datum.HasValue)
            {
                var odDatuma = datum.Value.Date;
                var doDatuma = odDatuma.AddDays(1);
                tekstovi = tekstovi.Where(x => odDatuma <= x.Datum && x.Datum <= doDatuma);
            }
            return tekstovi.ToArray();
        }

        public IEnumerable<Komentar> VratiKomentare(int? idTeksta)
        {
            if (!idTeksta.HasValue) return Enumerable.Empty<Komentar>();
            var tekst = DataContext.Tekstovi.Include("Komentari").Include("Komentari.Poslao").SingleOrDefault(x => x.ID == idTeksta);
            if (tekst == null) return Enumerable.Empty<Komentar>();
            return tekst.Komentari.OrderByDescending(x => x.Datum).ToArray();
        }
    }
}