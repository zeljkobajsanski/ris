using System;
using System.Collections.Generic;
using Rs.Dnevnik.Ris.Core.Model;

namespace Ris.Web.ViewModels
{
    public class AgencijskeVestiViewModel
    {
        public AgencijskeVestiViewModel()
        {
            Datum = DateTime.Now;
        }

        public DateTime? Datum { get; set; }
        public IEnumerable<AgencijskaVest> AgencijskeVesti { get; set; }
        public IEnumerable<Agencija> Agencije { get; set; }
        public int? DefaultAgencija { get; set; }
    }
}