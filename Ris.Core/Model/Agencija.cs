using System.ComponentModel.DataAnnotations;
using Rs.Dnevnik.Ris.Core.MyAnnotations;

namespace Rs.Dnevnik.Ris.Core.Model
{
    public class Agencija : Entity
    {
        [NazivJeObavezan]
        [StringLength(50, ErrorMessage = "Naziv je predugačak")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Email je obavezan")]
        [StringLength(50, ErrorMessage = "Email je predugačak")]
        public string EMail { get; set; }

        public bool Default { get; set; }
    }
}