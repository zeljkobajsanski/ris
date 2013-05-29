using System;

namespace Rs.Dnevnik.Ris.Core.Model
{
    public class ArhiviranTekst : Entity
    {
        public ArhiviranTekst()
        {
            Datum = DateTime.Now;
        }

        public DateTime Datum { get; set; }
        public string Html { get; set; }
        public int TekstID { get; set; }
        public Tekst Tekst { get; set; }
    }
}