using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rs.Dnevnik.Ris.Core.Model
{
    [Serializable]
    public class Radnik : Entity
    {
        private string m_Ime;
        private string m_Prezime;
        private int? m_OdeljenjeId;

        public Radnik()
        {
            UlogeRadnika = new List<UlogaRadnika>();
        }

        [Required(ErrorMessage = "Ime radnika je obavezno")]
        [StringLength(50, ErrorMessage = "Ime je predugačko")]
        public string Ime
        {
            get { return m_Ime; }
            set
            {
                if (value == m_Ime) return;
                m_Ime = value;
                OnPropertyChanged("Ime");
            }
        }

        [Required(ErrorMessage = "Prezime radnika je obavezno")]
        [StringLength(50, ErrorMessage = "Prezime je predugačko")]
        public string Prezime
        {
            get { return m_Prezime; }
            set
            {
                if (value == m_Prezime) return;
                m_Prezime = value;
                OnPropertyChanged("Prezime");
            }
        }

        public string ImeIPrezime
        {
            get { return Ime + " " + Prezime; }
        }

        public Odeljenje Odeljenje { get; set; }

        [Required(ErrorMessage = "Odeljenje nije izabrano")]
        public int? OdeljenjeID
        {
            get { return m_OdeljenjeId; }
            set
            {
                if (value == m_OdeljenjeId) return;
                m_OdeljenjeId = value;
                OnPropertyChanged("OdeljenjeID");
            }
        }

        public int SortOrder { get; set; }

        public IList<UlogaRadnika> UlogeRadnika { get; set; }
    }
}