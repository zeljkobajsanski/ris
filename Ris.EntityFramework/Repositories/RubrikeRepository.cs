using System.Collections.Generic;
using System.Data;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using System.Linq;

namespace Rs.Dnevnik.Ris.EntityFramework.Repositories
{
    public class RubrikeRepository : RepositoryBase, IRubrikeRepository
    {
        public RubrikeRepository()
        {
        }

        public RubrikeRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public ICollection<Rubrika> VratiRubrike(int? idPublikacije)
        {
            return DataContext.Rubrike.Where(x => x.PublikacijaID == idPublikacije).OrderBy(x => x.Naziv).ToList();
        }

        public ICollection<Rubrika> VratiSveRubrike()
        {
            return DataContext.Rubrike.ToArray();
        }

        public override void Add<T>(T entity)
        {
            var rubrika = entity as Rubrika;
            if (rubrika != null)
            {
                if (DataContext.Entry(rubrika).State == EntityState.Detached)
                {
                    DataContext.Rubrike.Add(rubrika);
                }
            }
        }
    }
}