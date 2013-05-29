using System;
using System.ComponentModel.DataAnnotations;

namespace Rs.Dnevnik.Ris.Core.Model
{
    [Serializable]
    public class RadniNalog : Entity
    {
        private int? fPublikacijaId;
        private int? fRubrikaId;
        private DateTime fDatum;
        private int? fRadnikId;
        private int? fOcenaId;
        private int fBrojStranice;
        private string fNapomena;

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

        public Rubrika Rubrika { get; set; }

        [Required(ErrorMessage = "Rubrika nije izabrana")]
        public int? RubrikaID
        {
            get { return fRubrikaId; }
            set
            {
                if (value == fRubrikaId) return;
                fRubrikaId = value;
                OnPropertyChanged("RubrikaID");
            }
        }

        public DateTime Datum
        {
            get { return fDatum; }
            set
            {
                if (value.Equals(fDatum)) return;
                fDatum = value;
                OnPropertyChanged("Datum");
            }
        }

        public Radnik Radnik { get; set; }

        [Required(ErrorMessage = "Radnik nije izabran")]
        public int? RadnikID
        {
            get { return fRadnikId; }
            set
            {
                if (value == fRadnikId) return;
                fRadnikId = value;
                OnPropertyChanged("RadnikID");
            }
        }

        public Ocena Ocena { get; set; }

        public int? OcenaID
        {
            get { return fOcenaId; }
            set
            {
                if (value == fOcenaId) return;
                fOcenaId = value;
                OnPropertyChanged("OcenaID");
            }
        }

        [Range(1, 200, ErrorMessage = "Broj stranice mora biti u opsegu 1~200")]
        public int BrojStranice
        {
            get { return fBrojStranice; }
            set
            {
                if (value == fBrojStranice) return;
                fBrojStranice = value;
                OnPropertyChanged("BrojStranice");
            }
        }

        public string Napomena
        {
            get { return fNapomena; }
            set
            {
                if (value == fNapomena) return;
                fNapomena = value;
                OnPropertyChanged("Napomena");
            }
        }

        public string TipAktivnosti { get; set; }
    }
}