namespace Rs.Dnevnik.Ris.Core.Model
{
    public class Konfiguracija : Entity
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int DownloadInterval { get; set; }
    }
}