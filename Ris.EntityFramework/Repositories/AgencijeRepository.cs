using System.Collections.Generic;
using System.Data;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using System.Linq;

namespace Rs.Dnevnik.Ris.EntityFramework.Repositories
{
    public class AgencijeRepository : RepositoryBase, IAgencijeRepository
    {
        public AgencijeRepository()
        {
        }

        public AgencijeRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public override void Add<T>(T entity)
        {
            var agencija = entity as Agencija;
            if (agencija != null && DataContext.Entry(entity).State == EntityState.Detached)
            {
                DataContext.Agencije.Add(agencija);
            }
        }

        public ICollection<Agencija> VratiAgencije()
        {
            return DataContext.Agencije.ToList();
        }

        public Agencija VratiAgencijuSaEmailom(string email)
        {
            return DataContext.Agencije.SingleOrDefault(x => x.EMail == email);
        }

        public int? VratiIdDefaultAgencije()
        {
            var prvaDefault = DataContext.Agencije.FirstOrDefault(x => x.Default);
            return prvaDefault != null ? prvaDefault.ID : (int?) null;
        }
    }
}