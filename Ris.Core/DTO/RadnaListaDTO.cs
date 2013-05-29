using System;

namespace Rs.Dnevnik.Ris.Core.DTO
{
    public class RadnaListaDTO
    {
        public int ID { get; set; }
        public int? TipTekstaID { get; set; }
        public string TipAktivnosti { get; set; }
        public DateTime Datum { get; set; }
        public int? RadnikID { get; set; }
        public string Radnik { get; set; }
        public int? RubrikaID { get; set; }
        public string Rubrika { get; set; }
        public int PublikacijaID { get; set; }
        public string Publikacija { get; set; }
        public int? OcenaID { get; set; }
        public string Naslov { get; set; }
        public int BrojStranice { get; set; }
        public int? Stubaca { get; set; }
        public int? Centimetara { get; set; }
        public string Napomena { get; set; }
    }
}