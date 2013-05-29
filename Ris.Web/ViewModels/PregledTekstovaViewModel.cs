using System;
using System.Collections.Generic;
using Rs.Dnevnik.Ris.Core.Model;

namespace Ris.Web.ViewModels
{
    public class PregledTekstovaViewModel
    {
        public IEnumerable<Publikacija> Publikacije { get; set; }
        public IEnumerable<Rubrika> Rubrike { get; set; }
        public IEnumerable<Radnik> Radnici { get; set; }
        public DateTime Datum { get; set; }
        public IEnumerable<Tekst> Tekstovi { get; set; }
        public bool DozvoliBrisanje { get; set; }
        public bool DozvoljenaIzmena { get; set; }
    }
}