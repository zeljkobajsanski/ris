using System;
using System.ComponentModel.DataAnnotations;
using Rs.Dnevnik.Ris.Core.MyAnnotations;

namespace Rs.Dnevnik.Ris.Core.Model
{
    [Serializable]
    public class Publikacija : Entity
    {
        [NazivJeObavezan]
        [StringLength(100, ErrorMessage = "Naziv je predugačak")]
        public string Naziv { get; set; } 

    }
}