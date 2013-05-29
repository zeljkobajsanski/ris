using System.Collections.Generic;
using System.Linq;
using Rs.Dnevnik.Ris.Core.Model;

namespace Ris.Web.ViewModels
{
    public class PublikacijaViewModel
    {
        public PublikacijaViewModel()
        {
            Publikacije = Enumerable.Empty<Publikacija>();
        }

        public string Name { get; set; }
        public bool ReadOnly { get; set; }
        public string ValueChanged { get; set; }
        public int? IdPublikacije { get; set; }
        public IEnumerable<Publikacija> Publikacije { get; set; } 
    }
}