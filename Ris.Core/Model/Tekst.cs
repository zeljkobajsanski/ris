using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rs.Dnevnik.Ris.Core.Model
{
    public class Tekst : Entity
    {
        private string m_Naslov;
        private string m_Nadnaslov;
        private string m_Podnaslov;
        private int? m_PublikacijaId;
        private int? m_RubrikaId;
        private DateTime? m_Datum;

        public Tekst()
        {
            Materijali = new List<Materijal>();
            Komentari = new List<Komentar>();
            ArhiviraniTekstovi = new List<ArhiviranTekst>();
        }

        [Required(ErrorMessage = "Publikacija nije izabrana")]
        public int? PublikacijaID
        {
            get { return m_PublikacijaId; }
            set
            {
                if (PublikacijaID != value)
                {
                    m_PublikacijaId = value;
                    Validate();
                }
            }
        }

        [Required(ErrorMessage = "Datum nije unet")]
        public DateTime? Datum
        {
            get { return m_Datum; }
            set
            {
                if (m_Datum != value)
                {
                    m_Datum = value;
                    OnPropertyChanged("Datum");
                }
            }
        }

        public Publikacija Publikacija { get; set; }

        [Required(ErrorMessage = "Rubrika nije izabrana")]
        public int? RubrikaID
        {
            get { return m_RubrikaId; }
            set
            {
                if (RubrikaID != value)
                {
                    m_RubrikaId = value;
                    Validate();
                }
            }
        }

        public Rubrika Rubrika { get; set; }

        public int? TipTekstaID { get; set; }

        public TipTeksta TipTeksta { get; set; }

        [StringLength(255, ErrorMessage = "Dužina je prevelika")]
        public string Nadnaslov
        {
            get { return m_Nadnaslov; }
            set
            {
                if (Nadnaslov != value)
                {
                    m_Nadnaslov = value;
                    Validate();
                }
            }
        }

        [Required(ErrorMessage = "Naslov nije unet")]
        [StringLength(255, ErrorMessage = "Dužina je prevelika")]
        public string Naslov
        {
            get { return m_Naslov; }
            set
            {
                if (Naslov != value)
                {
                    m_Naslov = value;
                    Validate();
                }
            }
        }

        [StringLength(255, ErrorMessage = "Dužina je prevelika")]
        public string Podnaslov
        {
            get { return m_Podnaslov; }
            set
            {
                if (Podnaslov != value)
                {
                    m_Podnaslov = value;
                    Validate();
                }
            }
        }

        public string Rtf { get; set; }

        public string PlainText { get; set; }

        public string Html { get; set; }

        public List<Materijal> Materijali { get; set; }

        public int AutorID { get; set; }

        public Radnik Autor { get; set; }

        public int TrenutnoKodID { get; set; }

        public UlogaRadnika TrenutnoKod { get; set; }

        public IList<Komentar> Komentari { get; set; }

        public int BrojKomentara { get; set; }

        public IList<ArhiviranTekst> ArhiviraniTekstovi { get; set; }
    }
}