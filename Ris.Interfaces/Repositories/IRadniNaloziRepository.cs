using System;
using System.Collections.Generic;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.Interfaces.Repositories
{
    public interface IRadniNaloziRepository : IRepository
    {
        ICollection<RadniNalog> RadniNalozi();
        IList<RadniNalog> VratiRadneNaloge(int idPublikacije, DateTime datum);
        ICollection<OstvarenjejRadnogNaloga> VratiIzvestajPoDatumu(int idRadnika, DateTime odDatuma, DateTime doDatuma);
        ICollection<OstvarenjejRadnogNaloga> VratiIzvestajPoRadnicima(int idPublikacije, DateTime odDatuma, DateTime doDatuma);
    }
}