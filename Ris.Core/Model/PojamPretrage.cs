using System.Collections.Generic;
using System.Linq;

namespace Rs.Dnevnik.Ris.Core.Model
{
    public class PojamPretrage
    {
        public string Pojam { get; set; }
        public List<string> Aliasi { get; set; }

        public PojamPretrage()
        {
            Aliasi = new List<string>();
        }

        public IEnumerable<string> GetAll()
        {
            return new[]{Pojam}.Union(Aliasi).ToArray();
        } 
    }
}