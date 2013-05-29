using System;

namespace Rs.Dnevnik.Ris.Win.Modules.RadniNalog
{
    public partial class RadniListNovinara : DevExpress.XtraEditors.XtraUserControl
    {
        private Core.Model.RadniListNovinara fModel;

        private int fIdPublikacije;

        public RadniListNovinara()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            Osvezi();
        }

        public void RadniList(Core.Model.RadniListNovinara model)
        {
            if (fIdPublikacije != model.PublikacijaID)
            {
                fIdPublikacije = model.PublikacijaID ?? 0;
                rubrika1.Properties.IdPublikacije = fIdPublikacije;
                rubrika1.Reload();
            }
            if (fModel != model)
            {
                fModel = model;
                radniListNovinaraBindingSource.DataSource = model;    
            }
        }

        public Core.Model.RadniListNovinara Model { get { return fModel; } }

        public void Osvezi()
        {
            publikacija1.Reload();
            radnik1.Reload();
            tipTeksta1.Reload();
            ocena1.Reload();
        }
    }
}
