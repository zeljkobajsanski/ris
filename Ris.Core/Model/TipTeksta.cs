using System;
using System.ComponentModel.DataAnnotations;
using Rs.Dnevnik.Ris.Core.MyAnnotations;

namespace Rs.Dnevnik.Ris.Core.Model
{
    [Serializable]
    public class TipTeksta : Entity
    {
        [NazivJeObavezan]
        [StringLength(50, ErrorMessage = "Naziv je predugačak")]
        public string Naziv { get; set; }
    }
}