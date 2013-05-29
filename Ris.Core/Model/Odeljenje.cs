using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Rs.Dnevnik.Ris.Core.MyAnnotations;

namespace Rs.Dnevnik.Ris.Core.Model
{
    [Serializable]
    public class Odeljenje : Entity
    {
        private string fNaziv;
        private int? fSektorId;
        private int? fPodrazumevanaPublikacijaId;
        private int? fPodrazumevanaRubrikaId;

        public Odeljenje()
        {
            Radnici = new List<Radnik>();
        }

        [StringLength(50, ErrorMessage = "Naziv je predugačak")]
        [NazivJeObavezan]
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

        public Sektor Sektor { get; set; }

        [Required(ErrorMessage = "Sektor nije izabran")]
        public int? SektorID
        {
            get { return fSektorId; }
            set
            {
                if (value == fSektorId) return;
                fSektorId = value;
                OnPropertyChanged("SektorID");
            }
        }

        public Publikacija PodrazumevanaPublikacija { get; set; }

        public int? PodrazumevanaPublikacijaID
        {
            get { return fPodrazumevanaPublikacijaId; }
            set
            {
                if (value == fPodrazumevanaPublikacijaId) return;
                fPodrazumevanaPublikacijaId = value;
                OnPropertyChanged("PodrazumevanaPublikacijaID");
            }
        }

        public Rubrika PodrazumevanaRubrika { get; set; }

        public int? PodrazumevanaRubrikaID
        {
            get { return fPodrazumevanaRubrikaId; }
            set
            {
                if (value == fPodrazumevanaRubrikaId) return;
                fPodrazumevanaRubrikaId = value;
                OnPropertyChanged("PodrazumevanaRubrikaID");
            }
        }

        public IList<Radnik> Radnici { get; set; }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == "PodrazumevanaPublikacijaID")
            {
                PodrazumevanaRubrikaID = null;
            }
        }
    }
}