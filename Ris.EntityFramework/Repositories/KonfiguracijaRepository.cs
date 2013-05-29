using System.Data;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using System.Linq;

namespace Rs.Dnevnik.Ris.EntityFramework.Repositories
{
    public class KonfiguracijaRepository : RepositoryBase, IKonfiguracijaRepository
    {
        public KonfiguracijaRepository()
        {
        }

        public KonfiguracijaRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public override void Add<T>(T entity)
        {
            var konfiguracija = entity as Konfiguracija;
            if (konfiguracija != null && DataContext.Entry(konfiguracija).State == EntityState.Detached)
            {
                DataContext.Konfiguracija.Add(konfiguracija);
            }
        }

        public Konfiguracija VratiKonfiguraciju()
        {
            return DataContext.Konfiguracija.Single();
        }
    }
}