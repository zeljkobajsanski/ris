using System.Collections.Generic;
using Rs.Dnevnik.Ris.Core.DTO;

namespace Ris.Spa.Models
{
    public class PretragaVesti
    {
        public IEnumerable<AgencijskaVestDTO> Vesti { get; set; }
        public IEnumerable<string> PojmoviPretrage { get; set; }
    }
}