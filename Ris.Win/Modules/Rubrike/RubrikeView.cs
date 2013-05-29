using System;
using System.ComponentModel;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Win.Utils;

namespace Rs.Dnevnik.Ris.Win.Modules.Rubrike
{
    public partial class RubrikeView : ViewBase, IRubrikeView
    {
        private readonly RubrikePresenter fPresenter;

        public RubrikeView()
        {
            InitializeComponent();
            fPresenter = new RubrikePresenter(this);
            PresenterBase = fPresenter;
            RegisterEvents();
        }

        protected override void OnLoad(EventArgs e)
        {
            publikacija1.Reload();
        }

        public override bool Sacuvaj()
        {
            gridView1.CloseEditor();
            return base.Sacuvaj();
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
            };
        }

        public void PrikaziRubrike(BindingList<Rubrika> rubrike)
        {
            rubrikaBindingSource.DataSource = rubrike;
        }

        public void FokusirajRubriku(Rubrika rubrika)
        {
            rubrikaBindingSource.MoveTo(rubrika);
        }
    }
}
