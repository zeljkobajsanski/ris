using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rs.Dnevnik.Ris.Win.Alerts;

namespace Rs.Dnevnik.Ris.Win.Modules
{
    public class ViewBase : XtraForm, IView
    {
        public event Action<AlertMessage> AlertEvent;

        protected PresenterBase PresenterBase;

        protected override void OnLoad(EventArgs e)
        {
            if (PresenterBase != null) PresenterBase.OnLoad();
        }

        protected override void OnClosed(System.EventArgs e)
        {
            if (PresenterBase != null)
            {
                PresenterBase.OnClose();
            }
            base.OnClosed(e);
        }

        public void ObavestiKorisnika(string poruka)
        {
            //XtraMessageBox.Show(this, poruka, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OnAlertEvent(new AlertMessage(poruka, AlertMessageType.Info));
        }

        public void UpozoriKorisnika(string poruka)
        {
            //XtraMessageBox.Show(this, poruka, "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            OnAlertEvent(new AlertMessage(poruka, AlertMessageType.Warning));
        }

        public void PirkaziGresku(Exception exception)
        {
            //XtraMessageBox.Show(this, exception.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            OnAlertEvent(new AlertMessage(exception.Message, AlertMessageType.Error));
        }

        public bool PitajKorisnika(string pitanje)
        {
            return DialogResult.Yes == XtraMessageBox.Show(this, pitanje, "Pitanje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        protected virtual void RegisterEvents()
        {
        }

        public virtual bool Sacuvaj()
        {
            return PresenterBase.Sacuvaj();
        }

        public virtual void NoviUnos()
        {
            PresenterBase.Novi();
        }

        public virtual void Otvori()
        {
            PresenterBase.Otvori();
        }

        public virtual void Stampaj()
        {
            PresenterBase.Stampaj();
        }

        public virtual void Osvezi(bool prikaziPoruku)
        {
            PresenterBase.Osvezi();
            if (prikaziPoruku) PrikaziAlert(new PodaciSuOsvezeniAlert());
        }

        public void PrikaziAlert(AlertMessage alertMessage)
        {
            OnAlertEvent(alertMessage);
        }

        protected virtual void OnAlertEvent(AlertMessage message)
        {
            Action<AlertMessage> handler = AlertEvent;
            if (handler != null) handler(message);
        }
    }
}