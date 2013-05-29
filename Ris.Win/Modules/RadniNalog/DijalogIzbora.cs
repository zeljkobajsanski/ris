using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Rs.Dnevnik.Ris.Win.Modules.RadniNalog
{
    public partial class DijalogIzbora : DevExpress.XtraEditors.XtraForm
    {
        public DijalogIzbora()
        {
            InitializeComponent();
            dateEdit1.EditValue = DateTime.Now.Date;
        }

        protected override void OnLoad(EventArgs e)
        {
            publikacija1.Reload();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult.Cancel != DialogResult)
            {
                e.Cancel = !IdPublikacije.HasValue || DialogResult == DialogResult.Cancel;
                if (!IdPublikacije.HasValue)
                {
                    labelControl1.Text = "Izaberite publikaciju";
                }
            } 
        }

        internal int? IdPublikacije
        {
            get
            {
                if (publikacija1.EditValue != null && publikacija1.EditValue != DBNull.Value)
                {
                    return Convert.ToInt32(publikacija1.EditValue);
                }
                return null;
            }
        }

        internal DateTime Datum
        {
            get { return dateEdit1.DateTime.Date; }
        }
    }
}