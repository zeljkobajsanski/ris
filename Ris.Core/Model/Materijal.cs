using System.ComponentModel.DataAnnotations;

namespace Rs.Dnevnik.Ris.Core.Model
{
    public class Materijal : Entity
    {
        [Required(ErrorMessage = "Putanja nije uneta")]
        public string Putanja { get; set; }

        public string Thumbnail { get; set; }

        public int InfoID { get; set; }

        public MaterijalInfo Info { get; set; }
    }
}