using System.Collections.Generic;
using System.Data;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using System.Linq;

namespace Rs.Dnevnik.Ris.EntityFramework.Repositories
{
    public class MaterijalRepository : RepositoryBase, IMaterijalRepository
    {
        public MaterijalRepository()
        {
        }

        public MaterijalRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public override void Add<T>(T entity)
        {
            var materijalInfo = entity as MaterijalInfo;
            if (materijalInfo != null && DataContext.Entry(materijalInfo).State == EntityState.Detached)
            {
                DataContext.MaterijalInfo.Add(materijalInfo);
            }
        }

        public IEnumerable<Materijal> VratiSveMaterijale(string naziv)
        {
            var materijali = DataContext.MaterijalInfo.AsQueryable();
            if (!string.IsNullOrEmpty(naziv))
            {
                materijali = materijali.Where(x => x.Naziv.Contains(naziv));
            }
            return materijali.SelectMany(x => x.Materijali).ToArray();
        }

        public IEnumerable<Materijal> VratiSveMaterijale()
        {
            return DataContext.Materijali.ToArray();
        }

        public IEnumerable<Materijal> Pretrazi(string naziv, string tag, int? idPublikacije, int? idGrupeMaterijala)
        {
            var materijali = DataContext.MaterijalInfo.AsQueryable();
            if (idPublikacije.HasValue)
            {
                materijali = materijali.Where(x => x.PublikacijaID == idPublikacije);
            }
            if (idGrupeMaterijala.HasValue)
            {
                materijali = materijali.Where(x => x.GrupaMaterijalaID == idGrupeMaterijala);
            }
            if (!string.IsNullOrEmpty(naziv))
            {
                materijali = materijali.Where(x => x.Naziv.Contains(naziv));
            }
            if (!string.IsNullOrEmpty(tag))
            {
                materijali = materijali.Where(x => x.Tagovi.Contains(tag));
            }
            return materijali.SelectMany(x => x.Materijali).ToArray();
        }

        public Materijal VratiMaterijal(int id)
        {
            return DataContext.Materijali.Single(x => x.ID == id);
        }
    }
}