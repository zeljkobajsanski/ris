using System;
using System.Collections.Generic;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.Interfaces.Repositories
{
    public interface IAgencijskeVestiRepository : IRepository
    {
        IEnumerable<AgencijskaVest> PretraziVesti(DateTime? datum, int? idAgencije, IEnumerable<PojamPretrage> pojmoviPretrage);
        AgencijskaVest VratiPoId(int id);
    }
}