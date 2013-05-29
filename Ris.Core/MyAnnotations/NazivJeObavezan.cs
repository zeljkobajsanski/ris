using System.ComponentModel.DataAnnotations;

namespace Rs.Dnevnik.Ris.Core.MyAnnotations
{
    public class NazivJeObavezan : RequiredAttribute
    {
        public NazivJeObavezan()
        {
            ErrorMessage = "Naziv je obavezan";
        }
    }
}