using System;
using System.ComponentModel.DataAnnotations;

namespace Rs.Dnevnik.Ris.Core.Model
{
    public class RadniListNovinara : RadniNalog
    {
        private int? fTipTekstaId;
        private string fNaslovTeksta;
        private int? fStubaca;
        private int? fCentimetara;

        public TipTeksta TipTeksta { get; set; }

        [Required(ErrorMessage = "Tip teksta nije izabran")]
        public int? TipTekstaID
        {
            get { return fTipTekstaId; }
            set
            {
                if (value == fTipTekstaId) return;
                fTipTekstaId = value;
                OnPropertyChanged("TipTekstaID");
            }
        }

        [Required(ErrorMessage = "Naslov teksta je obavezan")]
        [StringLength(250, ErrorMessage = "Dužina naslova teksta je predugačka")]
        public string NaslovTeksta
        {
            get { return fNaslovTeksta; }
            set
            {
                if (value == fNaslovTeksta) return;
                fNaslovTeksta = value;
                OnPropertyChanged("NaslovTeksta");
            }
        }

        public int? Stubaca
        {
            get { return fStubaca; }
            set
            {
                if (value == fStubaca) return;
                fStubaca = value;
                OnPropertyChanged("Stubaca");
            }
        }

        public int? Centimetara
        {
            get { return fCentimetara; }
            set
            {
                if (value == fCentimetara) return;
                fCentimetara = value;
                OnPropertyChanged("Centimetara");
            }
        }

        [StringLength(256, ErrorMessage = "Putanja stranice je predugačka")]
        public string Stranica { get; set; }
    }
}