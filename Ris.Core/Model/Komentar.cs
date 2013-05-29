using System;

namespace Rs.Dnevnik.Ris.Core.Model
{
    public class Komentar : Entity
    {
        public Komentar()
        {
            Datum = DateTime.Now;
        }

        public DateTime Datum { get; set; }
        
        public string TekstKomentara { get; set; }
        
        public int PoslaoID { get; set; }
        public Radnik Poslao { get; set; }
        
        public int TekstID { get; set; }
        public Tekst Tekst { get; set; }
    }
}