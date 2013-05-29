using System.ComponentModel.DataAnnotations;

namespace Rs.Dnevnik.Ris.Core.Model
{
    public class KorisnickiNalog : Entity
    {
        private string fKorisnickoIme;
        private byte[] fLozinka;
        private string fLozinkaPlain;

        [Required(ErrorMessage = "Korisničko ime nije uneto")]
        [StringLength(50, ErrorMessage = "Korisničko ime je predugačko [1~50]")]
        public string KorisnickoIme
        {
            get { return fKorisnickoIme; }
            set
            {
                if (fKorisnickoIme != value)
                {
                    fKorisnickoIme = value;
                    OnPropertyChanged("KorisnickoIme");
                }
            }
        }

        [Required(ErrorMessage = "Lozinka nije uneta")]
        public string LozinkaPlain
        {
            get { return fLozinkaPlain; }
            set
            {
                if (fLozinkaPlain != value)
                {
                    fLozinkaPlain = value;
                    OnPropertyChanged("LozinkaPlain");
                }
                
            }
        }

        [Required(ErrorMessage = "Lozinka nije uneta")]
        public byte[] Lozinka
        {
            get { return fLozinka; }
            set
            {
                if (fLozinka != value)
                {
                    fLozinka = value;
                    OnPropertyChanged("Lozinka");
                }
                
            }
        }

        public int RadnikID { get; set; }

        public Radnik Radnik { get; set; }
    }
}