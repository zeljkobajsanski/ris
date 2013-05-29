using System.Collections.Generic;
using System.Linq;
using Rs.Dnevnik.Ris.Core.Model;

namespace Ris.Web.ViewModels
{
    public class RubrikeViewModel
    {
        public RubrikeViewModel()
        {
            Rubrike = Enumerable.Empty<Rubrika>();
        }

        public string Name { get; set; }
        public bool ReadOnly { get; set; }
        public string BeginCallback { get; set; }
        public int? IdRubrike { get; set; }
        public IEnumerable<Rubrika> Rubrike { get; set; }
    }
}