using System.Collections.Generic;
using System.Data;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using System.Linq;

namespace Rs.Dnevnik.Ris.EntityFramework.Repositories
{
    public class UlogeRadnikaRepository : RepositoryBase, IUlogeRadnikaRepository
    {
        public UlogeRadnikaRepository()
        {
        }

        public UlogeRadnikaRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public override void Add<T>(T entity)
        {
            var u = entity as UlogaRadnika;
            if (u != null && DataContext.Entry(entity).State == EntityState.Detached)
            {
                DataContext.UlogeRadnika.Add(u);
            }
        }

        public IEnumerable<UlogaRadnika> VratiUloge()
        {
            return DataContext.UlogeRadnika.ToArray();
        }
    }
}