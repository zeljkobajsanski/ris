using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.Win.Modules.RadniNalog
{
    public partial class View : ViewBase, IView
    {
        private readonly Presenter fPresenter;

        private readonly RadniListNovinara fRadniListNovinara = new RadniListNovinara(){Dock = DockStyle.Fill};

        private readonly RadniListUrednika fRadniListUrednika = new RadniListUrednika(){Dock = DockStyle.Fill};

        public View()
        {
            InitializeComponent();
            fPresenter = new Presenter(this);
            PresenterBase = fPresenter;
            RegisterEvents();
            
            
        }

        protected override sealed void RegisterEvents()
        {
            btnNext.Click += (s, e) => radniNalogBindingSource.MoveNext();
            btnPrev.Click += (s, e) => radniNalogBindingSource.MovePrevious();
            repositoryItemButtonEdit1.ButtonClick += (s, e) =>
            {
                switch (e.Button.Index)
                {
                    case 0:
                        fPresenter.Kopiraj(FokusiraniNalog());
                        break;
                    case 1:
                        fPresenter.Obrisi(FokusiraniNalog());
                        break;
                }
            };
            btnDodaj.Click += (s, e) => fPresenter.DodajNovi();
            radniNalogBindingSource.CurrentChanged += (s, e) =>
            {
                var current = radniNalogBindingSource.Current;
                fPresenter.IzabranSledeciNalog(current);
                
            };
            tipAktivnosti.EditValueChanged += (s, e) =>
            {
                if (tipAktivnosti.EditValue != null &&
                    tipAktivnosti.EditValue != DBNull.Value)
                {
                    fPresenter.PromenjenTipAktivnosti(tipAktivnosti.EditValue as string);
                    //radniNalogBindingSource.ResetBindings(true);
                }
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            fPresenter.OnLoad();
            Osvezi(false);
        }

        public void PrikaziDijalogIzbora()
        {
            using (var dlg = new DijalogIzbora())
            {
                dlg.ShowDialog(this);
                fPresenter.OtvoriRadniNalog(dlg.IdPublikacije, dlg.Datum);
            }
        }

        public void Enable(bool enable)
        {
            gridView1.OptionsBehavior.Editable = enable;
            tipAktivnosti.Enabled = enable;
            btnDodaj.Enabled = enable;
        }

        public void PrikaziRadneNaloge(IList<Core.Model.RadniNalog> radniNalozi)
        {
            radniNalogBindingSource.DataSource = radniNalozi;
        }

        public void UcitajRubrike(int idPublikacije)
        {
            rubrikaRepositoryItem1.IdPublikacije = idPublikacije;
        }

        public void FokusirajStavku(Core.Model.RadniNalog stavka)
        {
            radniNalogBindingSource.Position = radniNalogBindingSource.IndexOf(stavka);
        }

        public Core.Model.RadniNalog FokusiraniRadniNalog
        {
            get
            {
                //return gridView1.GetFocusedRow() as Core.Model.RadniNalog;
                return radniNalogBindingSource.Current as Core.Model.RadniNalog;
            }
        }

        public void PostaviTipoveAktivnosti(TipAktivnosti[] tipoviAktivnosti)
        {
            tipAktivnostiBindingSource.DataSource = tipoviAktivnosti;
        }

        

        public void OmoguciIzborTipaAktivnosti(bool omoguci)
        {
            tipAktivnosti.Enabled = omoguci;
        }

        public void PrikaziRadniListNovinara(Core.Model.RadniListNovinara radniListNovinara)
        {
            panelControl1.Controls.Clear();
            //fRadniListNovinara.RadniList(radniListNovinara);
            panelControl1.Controls.Add(fRadniListNovinara);
        }

        public void PrikaziRadniListUrednika(Core.Model.RadniListUrednika radniListUrednika)
        {
            panelControl1.Controls.Clear();
            //fRadniListUrednika.RadniList(radniListUrednika);
            panelControl1.Controls.Add(fRadniListUrednika);
        }

        public void PostaviRadniListNovinara(Core.Model.RadniListNovinara radniListNovinara)
        {
            fRadniListNovinara.RadniList(radniListNovinara);
        }

        public void PostaviRadniListUrednika(Core.Model.RadniListUrednika radniListUrednika)
        {
            fRadniListUrednika.RadniList(radniListUrednika);
        }

        public void IzaberiTipAktivnosti(string tipAktivnosti)
        {
            this.tipAktivnosti.EditValue = tipAktivnosti;
        }

        public override void NoviUnos()
        {
            PrikaziDijalogIzbora();
        }

        public override void Otvori()
        {
            PrikaziDijalogIzbora();
        }

        public override void Osvezi(bool prikaziAlert)
        {
            fRadniListNovinara.Osvezi();
            fRadniListUrednika.Osvezi();
            publikacijaRepositoryItem1.Reload();
            radnikRepositoryItem1.Reload();
            if (prikaziAlert)
            {
                ObavestiKorisnika("Podaci su osveženi");
            }
        }

        private Core.Model.RadniNalog FokusiraniNalog()
        {
            return gridView1.GetFocusedRow() as Core.Model.RadniNalog;
        }
    }
}