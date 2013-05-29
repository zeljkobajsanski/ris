using System;
using System.Collections.Generic;
using System.Data;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using System.Linq;

namespace Rs.Dnevnik.Ris.EntityFramework.Repositories
{
    public class AgencijskeVestiRepository : RepositoryBase, IAgencijskeVestiRepository
    {
        public AgencijskeVestiRepository()
        {
        }

        public AgencijskeVestiRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public override void Add<T>(T entity)
        {
            var agencijskaVest = entity as AgencijskaVest;
            if (agencijskaVest != null && DataContext.Entry(agencijskaVest).State == EntityState.Detached)
            {
                DataContext.AgencijskeVesti.Add(agencijskaVest);
            }
        }

        public IEnumerable<AgencijskaVest> PretraziVesti(DateTime? datum, int? idAgencije, IEnumerable<PojamPretrage> pojmoviPretrage)
        {
            var query = DataContext.AgencijskeVesti.AsQueryable();
            if (datum.HasValue)
            {
                var pocetak = datum.Value.Date;
                var kraj = pocetak.AddDays(1);
                query = query.Where(x => pocetak <= x.DatumPrijema && x.DatumPrijema <= kraj);
            }
            if (idAgencije.HasValue)
            {
                query = query.Where(x => x.AgencijaID == idAgencije);
            }
            
            foreach (var pojamPretrage in pojmoviPretrage)
            {
                var s = pojamPretrage.GetAll();
                query = query.Where(x => s.Any(val => x.Body.Contains(val)));
            }
            
           return query.OrderByDescending(x => x.DatumPrijema).ToArray();
        }

        public AgencijskaVest VratiPoId(int id)
        {
            return DataContext.AgencijskeVesti.Single(x => x.ID == id);
        }

        public IEnumerable<AgencijskaVest> VratiAgencijskeVesti()
        {
            return DataContext.AgencijskeVesti.OrderByDescending(x => x.DatumPrijema).ToArray();
        }

        public IEnumerable<AgencijskaVest> VratiAgencijskeVesti(int? idAgencije)
        {
            if (idAgencije.HasValue)
            {
                return DataContext.AgencijskeVesti.Where(x => x.AgencijaID == idAgencije).OrderByDescending(x => x.DatumPrijema).ToArray();
            }
            return DataContext.AgencijskeVesti.OrderByDescending(x => x.DatumPrijema).ToArray();
        }
    }
}