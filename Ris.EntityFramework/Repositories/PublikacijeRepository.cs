using System.Collections.Generic;
using System.Data;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using System.Linq;

namespace Rs.Dnevnik.Ris.EntityFramework.Repositories
{
    public class PublikacijeRepository : RepositoryBase, IPublikacijeRepository
    {
        public PublikacijeRepository()
        {
        }

        public PublikacijeRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public ICollection<Publikacija> Publikacije()
        {
            return DataContext.Publikacije.OrderBy(x => x.Naziv).ToList();
        }

        public override void Add<T>(T entity)
        {
            var publikacija = entity as Publikacija;
            if (publikacija != null)
            {
                if (DataContext.Entry(publikacija).State == EntityState.Detached)
                {
                    DataContext.Publikacije.Add(publikacija);
                }
            }
        }
    }
}