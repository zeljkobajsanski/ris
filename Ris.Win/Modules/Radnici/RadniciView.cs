using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Win.Utils;

namespace Rs.Dnevnik.Ris.Win.Modules.Radnici
{
    public partial class RadniciView : ViewBase, IRadniciView
    {
        private readonly RadniciPresenter fPresenter;

        public RadniciView()
        {
            InitializeComponent();
            fPresenter = new RadniciPresenter(this);
            PresenterBase = fPresenter;
        }

        protected override void OnLoad(EventArgs e)
        {
            odeljenjeRepositoryItem1.Reload();
            base.OnLoad(e);
        }

        public void FokusirajRadnika(Radnik radnik)
        {
            radnikBindingSource.MoveTo(radnik);
        }

        public void PrikaziRadnike(BindingList<Radnik> radnici)
        {
            radnikBindingSource.DataSource = radnici;
        }

        public override bool Sacuvaj()
        {
            gridView1.CloseEditor();
            return base.Sacuvaj();
        }
    }
}