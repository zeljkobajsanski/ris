using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;

namespace Rs.Dnevnik.Ris.EntityFramework.Repositories
{
    public class RadniNaloziRepository : RepositoryBase, IRadniNaloziRepository
    {
        public RadniNaloziRepository()
        {
        }

        public RadniNaloziRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public ICollection<RadniNalog> RadniNalozi()
        {
            return DataContext.RadniNalozi.ToList();
        }

        public IList<RadniNalog> VratiRadneNaloge(int idPublikacije, DateTime datum)
        {
            return DataContext.RadniNalozi.Where(x => x.PublikacijaID == idPublikacije && x.Datum == datum).ToList();
        }

        public ICollection<OstvarenjejRadnogNaloga> VratiIzvestajPoDatumu(int idRadnika, DateTime odDatuma, DateTime doDatuma)
        {
            return DataContext.RadniNalozi.OfType<RadniListNovinara>().Where(x => x.RadnikID == idRadnika && odDatuma <= x.Datum && x.Datum <= doDatuma)
                      .Select(x => 
                          new OstvarenjejRadnogNaloga
                              {
                                  Datum = x.Datum, 
                                  BrojTekstova = 1,
                                  TipTekstaID = x.TipTekstaID.Value,
                                  TipTeksta = x.TipTeksta.Naziv
                              }).ToList();
        }

        public ICollection<OstvarenjejRadnogNaloga> VratiIzvestajPoRadnicima(int idPublikacije, DateTime odDatuma, DateTime doDatuma)
        {
            return DataContext.RadniNalozi.OfType<RadniListNovinara>().Where(x => odDatuma <= x.Datum && x.Datum <= doDatuma && x.PublikacijaID == idPublikacije)
                      .Select(x =>
                          new OstvarenjejRadnogNaloga
                          {
                              Datum = x.Datum,
                              BrojTekstova = 1,
                              TipTekstaID = x.TipTekstaID.Value,
                              TipTeksta = x.TipTeksta.Naziv,
                              RadnikID = x.RadnikID.Value,
                              Radnik = x.Radnik.Ime + " " + x.Radnik.Prezime
                          }).ToList();
        }

        public override void Add<T>(T entity)
        {
            var radniNalog = entity as RadniNalog;
            if (radniNalog != null)
            {
                if (DataContext.Entry(radniNalog).State == EntityState.Detached)
                {
                    DataContext.RadniNalozi.Add(radniNalog);
                }
            }
        }

        
    }
}