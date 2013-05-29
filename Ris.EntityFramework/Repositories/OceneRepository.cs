using System.Collections.Generic;
using System.Data;
using System.Linq;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;

namespace Rs.Dnevnik.Ris.EntityFramework.Repositories
{
    public class OceneRepository : RepositoryBase, IOceneRepository
    {
        public OceneRepository()
        {
        }

        public OceneRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public ICollection<Ocena> Ocene()
        {
            return DataContext.Ocene.OrderBy(x => x.Vrednost).ToList();
        }

        public override void Add<T>(T entity)
        {
            var ocena = entity as Ocena;
            if (ocena != null)
            {
                if (DataContext.Entry(ocena).State == EntityState.Detached)
                {
                    DataContext.Ocene.Add(ocena);
                }
            }
        }
    }
}