using System.Collections.Generic;
using System.Data;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using System.Linq;

namespace Rs.Dnevnik.Ris.EntityFramework.Repositories
{
    public class RadniciRepository : RepositoryBase, IRadniciRepository
    {
        public RadniciRepository()
        {
        }

        public RadniciRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public ICollection<Radnik> VratiRadnikeOdeljenja(int idOdeljenja)
        {
            return DataContext.Radnici.Where(x => x.OdeljenjeID == idOdeljenja).ToList();
        }

        public ICollection<Radnik> VratiRadnikeSektory(int idSektora)
        {
            return DataContext.Radnici.Where(x => x.Odeljenje.SektorID == idSektora).ToList();
        }

        public ICollection<Radnik> VratiRadnikeNovinskeKuce(int idNovinskeKuce)
        {
            return DataContext.Radnici.Where(x => x.Odeljenje.Sektor.NovinskaKucaID == idNovinskeKuce).ToList();
        }

        public ICollection<Radnik> VratiRadnike()
        {
            return DataContext.Radnici.OrderBy(x => x.Prezime).ThenBy(x => x.Ime).ToList();
        }

        public ICollection<Radnik> VratiRadnikePoRubrikama()
        {
            var radnici = new List<Radnik>();
            var odeljenja = DataContext.Odeljanja.Include("PodrazumevanaRubrika").Include("Radnici");
            foreach (var odeljenje in odeljenja)
            {
                foreach (var radnik in odeljenje.Radnici)
                {
                    radnik.SortOrder = odeljenje.PodrazumevanaRubrika != null ? odeljenje.PodrazumevanaRubrika.Sort : int.MaxValue;
                    radnici.Add(radnik);
                }
            }
            return radnici.OrderBy(x => x.SortOrder).ToList();
        }

        public Radnik VratiRadnikaSaUlogama(int idRadnika)
        {
            return DataContext.Radnici.Include("UlogeRadnika").SingleOrDefault(x => x.ID == idRadnika);
        }

        public override void Add<T>(T entity)
        {
            var radnik = entity as Radnik;
            if (radnik != null)
            {
                if (DataContext.Entry(radnik).State == EntityState.Detached)
                {
                    DataContext.Radnici.Add(radnik);
                }
            }
        }
    }
}