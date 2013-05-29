using System.ComponentModel.DataAnnotations;
using Rs.Dnevnik.Ris.Core.MyAnnotations;

namespace Rs.Dnevnik.Ris.Core.Model
{
    public class NovinskaKuca : Entity
    {
        [StringLength(100, ErrorMessage = "Naziv je predugačak")]
        //[Required(ErrorMessage = "Naziv nije unet")]
        //fiko
        [NazivJeObavezan]
        public string Naziv { get; set; }
    }
}