using System;
using System.ComponentModel.DataAnnotations;

namespace Rs.Dnevnik.Ris.Core.Model
{
    public class AgencijskaVest : Entity
    {
        //public DateTime DatumVesti { get; set; }
        public DateTime DatumPrijema { get; set; }
        [StringLength(255)]
        public string Subject { get; set; }
        public string Body { get; set; }
        public int AgencijaID { get; set; }
        public Agencija Agencija { get; set; }


    }
}