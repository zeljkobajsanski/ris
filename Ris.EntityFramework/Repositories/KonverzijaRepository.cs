using System.Collections.Generic;
using System.Data;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using System.Linq;

namespace Rs.Dnevnik.Ris.EntityFramework.Repositories
{
    public class KonverzijaRepository : RepositoryBase, IKonverzijaRepository
    {
        public KonverzijaRepository()
        {
        }

        public KonverzijaRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public override void Add<T>(T entity)
        {
            var konverzija = entity as Konverzija;
            if (konverzija != null && DataContext.Entry(konverzija).State == EntityState.Detached)
            {
                DataContext.Konverzija.Add(konverzija);
            }
        }

        public IEnumerable<Konverzija> VratiSabloneKonverzije()
        {
            return DataContext.Konverzija.ToArray();
        }
    }
}