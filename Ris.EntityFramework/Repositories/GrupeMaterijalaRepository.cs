using System.Collections.Generic;
using System.Data;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using System.Linq;

namespace Rs.Dnevnik.Ris.EntityFramework.Repositories
{
    public class GrupeMaterijalaRepository : RepositoryBase, IGrupeMaterijalaRepository
    {
        public GrupeMaterijalaRepository()
        {
        }

        public GrupeMaterijalaRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public override void Add<T>(T entity)
        {
            var gm = entity as GrupaMaterijala;
            if (gm != null && DataContext.Entry(gm).State == EntityState.Detached)
            {
                DataContext.GrupeMaterijala.Add(gm);
            }
        }

        public IEnumerable<GrupaMaterijala> VratiSve()
        {
            return DataContext.GrupeMaterijala.ToArray();
        }
    }
}