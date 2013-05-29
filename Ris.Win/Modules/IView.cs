using System;
using Rs.Dnevnik.Ris.Win.Alerts;

namespace Rs.Dnevnik.Ris.Win.Modules
{
    public interface IView
    {
        void ObavestiKorisnika(string poruka);
        void UpozoriKorisnika(string poruka);
        void PirkaziGresku(Exception exception);
        bool PitajKorisnika(string pitanje);
        bool Sacuvaj();
        void NoviUnos();
        void Otvori();
        void Osvezi(bool prikaziPoruku = true);
        void Stampaj();
        void PrikaziAlert(AlertMessage alertMessage);
        event Action<AlertMessage> AlertEvent;
    }
}