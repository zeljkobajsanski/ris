using System.Collections.Generic;
using System.Data;
using System.Linq;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;

namespace Rs.Dnevnik.Ris.EntityFramework.Repositories
{
    public class TipoviTekstaRepository : RepositoryBase, ITipoviTekstovaRepository
    {
        public TipoviTekstaRepository()
        {
        }

        public TipoviTekstaRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public ICollection<TipTeksta> TipoviTekstova()
        {
            return DataContext.TipoviTeksta.OrderBy(x => x.Naziv).ToList();
        }

        public override void Add<T>(T entity)
        {
            var tipTeksta = entity as TipTeksta;
            if (tipTeksta != null)
            {
                if (DataContext.Entry(tipTeksta).State == EntityState.Detached)
                {
                    DataContext.TipoviTeksta.Add(tipTeksta);
                }
            }
        }
    }
}