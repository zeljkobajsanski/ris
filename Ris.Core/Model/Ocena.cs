using System;
using System.ComponentModel.DataAnnotations;

namespace Rs.Dnevnik.Ris.Core.Model
{
    [Serializable]
    public class Ocena : Entity
    {
        [Required(ErrorMessage = "Opis ocene je obavezan")]
        [StringLength(20, ErrorMessage = "Opis ocene je predugačak")]
        public string Opis { get; set; }

        public int Vrednost { get; set; }
    }
}