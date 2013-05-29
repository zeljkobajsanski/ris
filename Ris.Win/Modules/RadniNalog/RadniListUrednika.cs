using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Rs.Dnevnik.Ris.Win.Modules.RadniNalog
{
    public partial class RadniListUrednika : DevExpress.XtraEditors.XtraUserControl
    {

        private int fIdPublikacije;

        public RadniListUrednika()
        {
            InitializeComponent();
        }

        public Core.Model.RadniListUrednika Model { get; private set; }

        protected override void OnLoad(EventArgs e)
        {
            Osvezi();
        }

        public void RadniList(Core.Model.RadniListUrednika model)
        {
            if (fIdPublikacije != model.PublikacijaID)
            {
                fIdPublikacije = model.PublikacijaID ?? 0;
                rubrika1.Properties.IdPublikacije = fIdPublikacije;
                rubrika1.Reload();
            }
            if (Model != model)
            {
                Model = model;
                radniListUrednikaBindingSource.DataSource = model;  
            }
        }

        public void Osvezi()
        {
            publikacija1.Reload();
            radnik1.Reload();
            ocena1.Reload();
        }
    }
}
