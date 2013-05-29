using System;

namespace Rs.Dnevnik.Ris.Core.Model
{
    public class OstvarenjejRadnogNaloga
    {
        public int RadnikID { get; set; }
        public string Radnik { get; set; }
        public int TipTekstaID { get; set; }
        public string TipTeksta { get; set; }
        public DateTime Datum { get; set; }
        public int BrojTekstova { get; set; }
    }
}