using System;
using System.ComponentModel.DataAnnotations;
using Rs.Dnevnik.Ris.Core.MyAnnotations;

namespace Rs.Dnevnik.Ris.Core.Model
{
    [Serializable]
    public class Rubrika : Entity
    {
        private string fNaziv;
        private int? fPublikacijaId;

        [NazivJeObavezan]
        [StringLength(100, ErrorMessage = "Naziv je predugačak")]
        public string Naziv
        {
            get { return fNaziv; }
            set
            {
                if (value == fNaziv) return;
                fNaziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        public Publikacija Publikacija { get; set; }

        [Required(ErrorMessage = "Publikacija nije izabrana")]
        public int? PublikacijaID
        {
            get { return fPublikacijaId; }
            set
            {
                if (value == fPublikacijaId) return;
                fPublikacijaId = value;
                OnPropertyChanged("PublikacijaID");
            }
        }

        public int Sort { get; set; }
    }
}