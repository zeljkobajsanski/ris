using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Win.Alerts;
using Rs.Dnevnik.Ris.Win.Properties;

namespace Rs.Dnevnik.Ris.Win.Modules.IzvestajRadnihNalog
{
    public partial class IzvestajPoDatumuView : ViewBase, IIzvestajPoDatumuView
    {
        private readonly IzvestajPoDatumuPresenter fPresenter;

        public IzvestajPoDatumuView()
        {
            InitializeComponent();
            fPresenter = new IzvestajPoDatumuPresenter(this);
            PresenterBase = fPresenter;
            RegisterEvents();
        }

        protected override sealed void RegisterEvents()
        {
            dateEdit1.EditValueChanged += (s, e) =>
            {
                fPresenter.OdDatuma = dateEdit1.DateTime;
            };
            dateEdit2.EditValueChanged += (s, e) =>
            {
                fPresenter.DoDatuma = dateEdit2.DateTime;
            };
            simpleButton1.Click += (s, e) => fPresenter.Prikazi(radnik1.IzabraniId);
            pivotGridControl1.CustomCellDisplayText += (s, e) =>
            {
                var value = Convert.ToInt32(e.Value);
                e.DisplayText = value > 0
                                    ? value.ToString()
                                    : string.Empty;
            };
            pivotGridControl1.CustomDrawCell += (s, e) =>
            {
                var value = Convert.ToInt32(e.Value);
                if (value > 0)
                {
                    e.Appearance.DrawBackground(e.Graphics, e.GraphicsCache, e.Bounds);
                    e.Graphics.DrawImageUnscaledAndClipped(Resources.cancel_16, new Rectangle(e.Bounds.X + e.Bounds.Width / 2 - 18, e.Bounds.Y + e.Bounds.Height / 2 - 8, 16, 16));
                    e.Graphics.DrawString(value.ToString(), e.Appearance.Font, new SolidBrush(Color.Black), e.Bounds.X + e.Bounds.Width / 2 + 2, e.Bounds.Y + e.Bounds.Height / 2 - 8);
                    e.Handled = true;
                }
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            Osvezi(false);
            fPresenter.OnLoad();
        }

        public void PostaviOdDatuma(DateTime odDatuma)
        {
            dateEdit1.DateTime = odDatuma;
        }

        public void PostaviDoDatuma(DateTime doDatuma)
        {
            dateEdit2.DateTime = doDatuma;
        }

        public void PrikaziIzvestaj(ICollection<OstvarenjejRadnogNaloga> izvestaj)
        {
            ostvarenjejRadnogNalogaBindingSource.DataSource = izvestaj;
        }

        public override void Osvezi(bool prikaziPoruku)
        {
            radnik1.Reload();
            if (prikaziPoruku)
            {
                OnAlertEvent(new PodaciSuOsvezeniAlert());
            }
        }
    }
}