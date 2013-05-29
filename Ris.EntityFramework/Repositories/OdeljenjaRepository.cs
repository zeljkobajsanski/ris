using System.Collections.Generic;
using System.Data;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using System.Linq;

namespace Rs.Dnevnik.Ris.EntityFramework.Repositories
{
    public class OdeljenjaRepository : RepositoryBase, IOdeljenjaRepository
    {
        public OdeljenjaRepository()
        {
        }

        public OdeljenjaRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public ICollection<Odeljenje> VratiOdeljenja(int idSektora)
        {
            return DataContext.Odeljanja.Where(x => x.SektorID == idSektora).ToList();
        }

        public ICollection<Odeljenje> VratiOdeljenja()
        {
            return DataContext.Odeljanja.ToList();
        }

        public override void Add<T>(T entity)
        {
            var odeljenje = entity as Odeljenje;
            if (odeljenje != null)
            {
                if (DataContext.Entry(odeljenje).State == EntityState.Detached)
                {
                    DataContext.Odeljanja.Add(odeljenje);
                }
            }
        }
    }
}