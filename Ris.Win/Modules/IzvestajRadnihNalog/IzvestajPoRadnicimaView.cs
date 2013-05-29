using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Win.Properties;

namespace Rs.Dnevnik.Ris.Win.Modules.IzvestajRadnihNalog
{
    public partial class IzvestajPoRadnicimaView : ViewBase, IIzvestajPoRadnicimaView
    {
        private readonly IzvestajPoRadnicimaPresenter fPresenter;

        public IzvestajPoRadnicimaView()
        {
            InitializeComponent();
            fPresenter = new IzvestajPoRadnicimaPresenter(this);
            PresenterBase = fPresenter;
            RegisterEvents();
        }

        protected override sealed void RegisterEvents()
        {
            publikacija1.EditValueChanged += (s, e) =>
            {
                if (publikacija1.EditValue != null &&
                    publikacija1.EditValue != DBNull.Value)
                {
                    fPresenter.IdPublikacije = Convert.ToInt32(publikacija1.EditValue);
                }
                else
                {
                    fPresenter.IdPublikacije = null;
                }
            };
            dateEdit1.DateTimeChanged += (s, e) => fPresenter.OdDatuma = dateEdit1.DateTime;
            dateEdit2.DateTimeChanged += (s, e) => fPresenter.DoDatuma = dateEdit2.DateTime;
            simpleButton1.Click += (s, e) => fPresenter.Prikazi();
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
            fPresenter.OnLoad();
            publikacija1.Reload();
        }

        public override void Osvezi(bool prikaziPoruku)
        {
            fPresenter.Prikazi();
        }

        public void PostaviOdDatuma(DateTime odDatuma)
        {
            dateEdit1.EditValue = odDatuma;
        }

        public void PostaviDoDatuma(DateTime doDatuma)
        {
            dateEdit2.EditValue = doDatuma;
        }

        public void PrikaziIzvestaj(ICollection<OstvarenjejRadnogNaloga> izvestaj)
        {
            ostvarenjejRadnogNalogaBindingSource.DataSource = izvestaj;
        }
    }
}