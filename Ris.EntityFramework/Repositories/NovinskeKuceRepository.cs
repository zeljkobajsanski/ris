using System.Collections.Generic;
using System.Data;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using System.Linq;

namespace Rs.Dnevnik.Ris.EntityFramework.Repositories
{
    public class NovinskeKuceRepository : RepositoryBase, INovinskeKuceRepository
    {
        public NovinskeKuceRepository()
        {
        }

        public NovinskeKuceRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public ICollection<NovinskaKuca> NovinskeKuce()
        {
            return DataContext.NovinskeKuce.ToList();
        }

        public override void Add<T>(T entity)
        {
            var novinskaKuca = entity as NovinskaKuca;
            if (novinskaKuca != null)
            {
                if (DataContext.Entry(novinskaKuca).State == EntityState.Detached)
                {
                    DataContext.NovinskeKuce.Add(novinskaKuca);
                }
            }
        }
    }
}