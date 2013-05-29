using System;
using System.ComponentModel.DataAnnotations;
using Rs.Dnevnik.Ris.Core.MyAnnotations;

namespace Rs.Dnevnik.Ris.Core.Model
{
    [Serializable]
    public class Sektor : Entity
    {
        [StringLength(50, ErrorMessage = "Naziv je predugačak")]
        //[Required(ErrorMessage = "Naziv nije unet")]
        [NazivJeObavezan]
        public string Naziv { get; set; }

        public NovinskaKuca NovinskaKuca { get; set; }

        [Required(ErrorMessage = "Izaberite novinsku kuću")]
        public int? NovinskaKucaID { get; set; }
    }
}