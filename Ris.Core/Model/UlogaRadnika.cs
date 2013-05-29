using Rs.Dnevnik.Ris.Core.MyAnnotations;

namespace Rs.Dnevnik.Ris.Core.Model
{
    public class UlogaRadnika : Entity
    {
        [NazivJeObavezan]
        public string Naziv { get; set; }
    }
}