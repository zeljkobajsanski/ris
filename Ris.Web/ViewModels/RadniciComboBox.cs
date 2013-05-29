using System.Collections.Generic;
using Rs.Dnevnik.Ris.Core.Model;

namespace Ris.Web.ViewModels
{
    public class RadniciComboBox : Editor
    {
        public int? IzabraniRadnik { get; set; }
        public IEnumerable<Radnik> Radnici { get; set; }    
    }
}