using System.Collections.Generic;
using System.Data;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using System.Linq;

namespace Rs.Dnevnik.Ris.EntityFramework.Repositories
{
    public class SektoriRepository : RepositoryBase, ISektoriRepository
    {
        public SektoriRepository()
        {
        }

        public SektoriRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public ICollection<Sektor> VratiSektore(int idNovinskeKuce)
        {
            //return DataContext.Sektori.Where(x => x.NovinskaKucaID == idNovinskeKuce).ToList();
            return DataContext.Sektori.ToList();
        }

        public override void Add<T>(T entity)
        {
            var sektor = entity as Sektor;
            if (sektor != null)
            {
                if (DataContext.Entry(sektor).State == EntityState.Detached)
                {
                    DataContext.Sektori.Add(sektor);
                }
            }
        }
    }
}