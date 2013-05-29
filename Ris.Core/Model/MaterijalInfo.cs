using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Rs.Dnevnik.Ris.Core.MyAnnotations;

namespace Rs.Dnevnik.Ris.Core.Model
{
    public class MaterijalInfo : Entity
    {
        private string m_Naziv;

        public MaterijalInfo()
        {
            Materijali = new List<Materijal>();
        }

        [NazivJeObavezan]
        [StringLength(50, ErrorMessage = "Naziv je predugačak")]
        public string Naziv
        {
            get { return m_Naziv; }
            set
            {
                if (m_Naziv != value)
                {
                    m_Naziv = value;    
                    Validate();
                }
            }
        }

        public string Opis { get; set; }

        public DateTime? Kreiran { get; set; }

        public int? PublikacijaID { get; set; }

        public Publikacija Publikacija { get; set; }

        [StringLength(256, ErrorMessage = "Tagovi su predugački")]
        public string Tagovi { get; set; }

        public int? GrupaMaterijalaID { get; set; }

        public GrupaMaterijala GrupaMaterijala { get; set; }

        public int? RadnikID { get; set; }

        public Radnik Radnik { get; set; }

        public ICollection<Materijal> Materijali { get; set; }
    }
}