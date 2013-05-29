using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rs.Dnevnik.Ris.Core.DTO
{
    public class AgencijskaVestDTO
    {
        public int ID { get; set; }
        public DateTime Datum { get; set; }
        public string Agencija { get; set; }
        public string Naslov { get; set; }
        public string Body { get; set; }
    }
}
