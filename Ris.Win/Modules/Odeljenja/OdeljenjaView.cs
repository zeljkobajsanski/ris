using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using Rs.Dnevnik.Ris.Win.Editors;
using Rs.Dnevnik.Ris.Win.Utils;
using Odeljenje = Rs.Dnevnik.Ris.Core.Model.Odeljenje;

namespace Rs.Dnevnik.Ris.Win.Modules.Odeljenja
{
    public partial class OdeljenjaView : ViewBase, IOdeljenjaView
    {
        private readonly OdeljenjaPresenter fPresenter;

        private readonly RubrikaRepositoryItem fRubrikaRepositoryItem = new RubrikaRepositoryItem();

        public OdeljenjaView()
        {
            InitializeComponent();
            fRubrikaRepositoryItem.Columns.Add(new LookUpColumnInfo("Naziv", "Naziv rubrike"));
            fPresenter = new OdeljenjaPresenter(this);
            PresenterBase = fPresenter;
            RegisterEvents();
        }

        protected sealed override void RegisterEvents()
        {
            sektor1.EditValueChanged += (s, e) =>
            {
                var value = sektor1.EditValue;
                if (value != null && value != DBNull.Value)
                {
                    fPresenter.IdSektora = Convert.ToInt32(value);
                }
            };
            gridView1.CustomRowCellEditForEditing += DodeliEditor;
            gridView1.CustomRowCellEdit += DodeliEditor;
        }

        private void DodeliEditor(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column == colPodrazumevanaRubrikaID)
            {
                var odeljenje =
                    gridView1.GetRow(e.RowHandle) as Odeljenje;
                if (odeljenje != null)
                {
                    if (odeljenje.PodrazumevanaPublikacijaID.HasValue)
                    {
                        fRubrikaRepositoryItem.IdPublikacije = odeljenje.PodrazumevanaPublikacijaID.Value;
                    }
                }
                e.RepositoryItem = fRubrikaRepositoryItem;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            sektor1.Reload();
            publikacijaRepositoryItem1.Reload();
            fRubrikaRepositoryItem.Reload();
            base.OnLoad(e);
        }

        public override void Osvezi(bool prikaziPoruku)
        {
            sektor1.Reload();
            base.Osvezi(prikaziPoruku);
        }

        public override bool Sacuvaj()
        {
            gridView1.CloseEditor();
            return base.Sacuvaj();
        }

        public void PrikaziOdeljenja(BindingList<Odeljenje> odeljenja)
        {
            odeljenjeBindingSource.DataSource = odeljenja;
        }

        public void FokusirajOdeljenje(Odeljenje odeljenje)
        {
            odeljenjeBindingSource.MoveTo(odeljenje);
        }
    }
}
