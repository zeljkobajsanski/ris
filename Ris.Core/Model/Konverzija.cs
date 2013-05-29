using System.ComponentModel.DataAnnotations;

namespace Rs.Dnevnik.Ris.Core.Model
{
    public class Konverzija : Entity
    {
        [Required(ErrorMessage = "Šablon konverzije nije unet")]
        [StringLength(20, ErrorMessage = "Šablon konverzije je predugačak [1~20]")]
        public string Sablon { get; set; }

        [Required(ErrorMessage = "Konverovani string nije unet")]
        [StringLength(20, ErrorMessage = "Konvertovani string je predugačak [1~20]")]
        public string KonverovaniString { get; set; }
    }
}