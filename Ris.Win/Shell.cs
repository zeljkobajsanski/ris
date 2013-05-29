using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ninject;
using Rs.Dnevnik.Ris.Win.Alerts;
using Rs.Dnevnik.Ris.Win.Modules.IzvestajRadnihNalog;
using Rs.Dnevnik.Ris.Win.Modules.Odeljenja;
using Rs.Dnevnik.Ris.Win.Modules.RadniNalog;
using Rs.Dnevnik.Ris.Win.Modules.Radnici;
using Rs.Dnevnik.Ris.Win.Modules.Rubrike;

namespace Rs.Dnevnik.Ris.Win
{
    public partial class Shell : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Shell()
        {
            InitializeComponent();
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            RegistrujKomande();
            RegistrujMeni();
        }

        private void RegistrujKomande()
        {
            btnSave.ItemClick += (s, e) =>
                                     {
                                         var active = GetActiveView();
                                         if (active != null)
                                         {
                                             try
                                             {
                                                 PrikaziCekalicu();
                                                 if (active.Sacuvaj())
                                                 {
                                                     PrikaziAlert(new PodaciSuSnimljeniAlert());    
                                                 }
                                             }
                                             finally
                                             {
                                                 progressPanel1.Visible = false;
                                             }
                                         }
                                     };
            btnNew.ItemClick += (s, e) =>
                                    {
                                        var active = GetActiveView();
                                        if (active != null)
                                        {
                                            active.NoviUnos();
                                        }
                                    };
            btnOpen.ItemClick += (s, e) =>
                                     {
                                         var active = GetActiveView();
                                         if (active != null)
                                         {
                                             active.Otvori();
                                         }
                                     };
            btnRefresh.ItemClick += (s, e) =>
                                        {
                                            var active = GetActiveView();
                                            if (active != null)
                                            {
                                                try
                                                {
                                                    PrikaziCekalicu();
                                                    active.Osvezi();
                                                }
                                                finally
                                                {
                                                    progressPanel1.Visible = false;
                                                }
                                            }
                                        };
            btnPrint.ItemClick += (s, e) =>
                                      {
                                          var active = GetActiveView();
                                          if (active != null)
                                          {
                                              active.Stampaj();
                                          }
                                      };
        }

        private void RegistrujMeni()
        {
            btnUnosRadnogNaloga.LinkPressed += (s, e) =>
                                                   {
                                                       var view = IoC.Container.GetKernel().Get<IView>();
                                                       AktivirajModul(view);
                                                   };
            btnPregledRnPoDanima.LinkPressed += (s, e) =>
                                                    {
                                                        var view = IoC.Container.GetKernel().Get<IIzvestajPoDatumuView>();
                                                        AktivirajModul(view);
                                                    };
            btnPregledRadnihNalogaPoRadnicima.LinkPressed += (s, e) =>
                                                                 {
                                                                     var view =
                                                                         IoC.Container.GetKernel()
                                                                            .Get<IIzvestajPoRadnicimaView>();
                                                                     AktivirajModul(view);
                                                                 };
            btnRadnici.LinkPressed += (s, e) =>
            {
                var view = IoC.Container.GetKernel().Get<IRadniciView>();
                AktivirajModul(view);
            };
            btnRubrike.LinkPressed += (s, e) =>
            {
                var view = IoC.Container.GetKernel().Get<IRubrikeView>();
                AktivirajModul(view);
            };
            btnOdeljenja.LinkPressed +=
                    (s, e) =>
                    {
                        var view = IoC.Container.GetKernel().Get<IOdeljenjaView>();
                        AktivirajModul(view);
                    };
        }

        private void AktivirajModul(Modules.IView view)
        {
            view.AlertEvent += PrikaziAlert;
            ShowDocument((XtraForm)view);
        }

        private void PrikaziAlert(AlertMessage message)
        {
            switch (message.MessageType)
            {
                    case AlertMessageType.Info:
                    alertControl1.Show(this, "Obaveštenje", message.Message, Properties.Resources.Ribbon_Info_32x32);
                        break;
                    case AlertMessageType.Warning:
                        alertControl1.Show(this, "Upozorenje", message.Message, Properties.Resources.warning_32x32);
                        break;
                    case AlertMessageType.Error:
                        alertControl1.Show(this, "Greška", message.Message, Properties.Resources.error_32x32);
                        break;
            }
        }

        private Modules.IView GetActiveView()
        {
            var ad = documentManager1.View.ActiveDocument;
            if (ad != null)
            {
                return (Modules.IView) ad.Control;
            }
            return null;
        }

        private void ShowDocument(XtraForm view)
        {
            try
            {
                documentManager1.View.BeginUpdate();
                documentManager1.View.Controller.AddDocument(view);
            }
            finally 
            {
                documentManager1.View.EndUpdate();
            }
        }

        private void PrikaziCekalicu()
        {
            progressPanel1.Visible = true;
            var loc = new Point(Size.Width / 2 - progressPanel1.Width / 2,
                                Size.Height / 2 - progressPanel1.Height / 2);
            progressPanel1.Location = loc;
            Application.DoEvents();
        }
    }
}