using System;
using System.Collections.Generic;
using System.ComponentModel;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Win.Models;
using System.Linq;

namespace Rs.Dnevnik.Ris.Win.Modules.RadniNalog
{
    public class Presenter : PresenterBase
    {
        private BindingList<Core.Model.RadniNalog> fRadniNalozi = new BindingList<Core.Model.RadniNalog>(); 

        private readonly IView fView;

        private DateTime fDatum;

        private int fIdPublikacije;

        private PrikazRadnogLista fPrikazRadnogLista;

        private Core.Model.RadniNalog fTekuciRadniList;

        public Presenter(IView view)
        {
            fView = view;
        }

        public override void OnLoad()
        {
            fView.Enable(false);
            var tipoviAktivnosti = new[]{new TipAktivnosti {Id = "NT", Naziv = "Napisan tekst"},
                                         new TipAktivnosti {Id = "UT", Naziv = "Uređen tekst" }};
            fView.PostaviTipoveAktivnosti(tipoviAktivnosti);
        }

        public override bool Sacuvaj()
        {
            //if (fTekuciRadniList != null && fTekuciRadniList.IsValid)
            //{
            //    RepositoryFactory.RadniNaloziRepository.Add(fTekuciRadniList);
            //    RepositoryFactory.RadniNaloziRepository.Save();
            //    return true;
            //}
            //return false;
            if (!fRadniNalozi.Any()) return false;
            //if (fRadniNalozi.Any(x => !x.IsValid))
            //{
            //    fView.UpozoriKorisnika("Ispravite sve greške pre snimanja");
            //    return false;   
            //}
            foreach (var radniNalog in fRadniNalozi.Where(x => x.IsValid))
            {
                RepositoryFactory.RadniNaloziRepository.Add(radniNalog);
            }
            try
            {
                RepositoryFactory.RadniNaloziRepository.Save();
                return true;
            }
            catch (Exception exc)
            {
                fView.PirkaziGresku(exc);
                return false;
            }
        }

        public void OtvoriRadniNalog(int? idPublikacije, DateTime datum)
        {
            if (!idPublikacije.HasValue)
            {
                fView.Enable(false);
                return;
            }
            fIdPublikacije = idPublikacije.Value;
            fDatum = datum;
            fView.Enable(true);
            fView.UcitajRubrike(idPublikacije.Value);
            var rn = RepositoryFactory.RadniNaloziRepository.VratiRadneNaloge(idPublikacije.Value, datum);
            KreirajRadneNaloge(idPublikacije.Value, datum, rn);
        }

        private void KreirajRadneNaloge(int idPublikacije, DateTime datum, IList<Core.Model.RadniNalog> radniNalozi)
        {
            var odeljenja = RepositoryFactory.OdeljenjaRepository.VratiOdeljenja().ToDictionary(x => x.ID);
            fRadniNalozi = new BindingList<Core.Model.RadniNalog>(radniNalozi);
            var radnici = RepositoryFactory.RadniciRepository.VratiRadnikePoRubrikama();
            foreach (var radnik in radnici)
            {
                if (radniNalozi.Any(x => x.RadnikID == radnik.ID)) continue;
                var radniNalog = new Core.Model.RadniListNovinara();
                radniNalog.Datum = datum;
                radniNalog.PublikacijaID = idPublikacije;
                radniNalog.RadnikID = radnik.ID;
                var odeljenjeRadnika = odeljenja[radnik.OdeljenjeID.Value];
                radniNalog.RubrikaID = odeljenjeRadnika.PodrazumevanaRubrikaID;
                fRadniNalozi.Add(radniNalog);
            }
            fView.PrikaziRadneNaloge(fRadniNalozi);
        }

        public void Kopiraj(Core.Model.RadniNalog stavka)
        {
            if (stavka == null) return;
            if (fView.PitajKorisnika("Da li želite da kopirate stavku?"))
            {
                Core.Model.RadniNalog novaStavka = null;
                if (stavka as Core.Model.RadniListNovinara != null)
                {
                    novaStavka = new Core.Model.RadniListNovinara();
                }
                if (stavka as Core.Model.RadniListUrednika != null)
                {
                    novaStavka = new Core.Model.RadniListUrednika();
                }
                
                novaStavka.Datum = stavka.Datum;
                novaStavka.PublikacijaID = stavka.PublikacijaID;
                novaStavka.RadnikID = stavka.RadnikID;
                novaStavka.RubrikaID = stavka.RubrikaID;
                fRadniNalozi.Add(novaStavka);
                fView.FokusirajStavku(novaStavka);
            }
        }

        public void Obrisi(Core.Model.RadniNalog stavka)
        {
            if (stavka == null) return;
            if (fView.PitajKorisnika("Da li želite da obrišete stavku?"))
            {
                fRadniNalozi.Remove(stavka);
                RepositoryFactory.RadniNaloziRepository.Remove(stavka);
            }
        }

        public void DodajNovi()
        {
            if (fView.PitajKorisnika("Da li želite da dodate novu stavku?"))
            {
                var nova = new Core.Model.RadniListNovinara {Datum = fDatum, PublikacijaID = fIdPublikacije};
                fRadniNalozi.Add(nova);
                fView.FokusirajStavku(nova);
            }
        }

        public void PromenjenTipAktivnosti(string tipAktivnosti)
        {
            var radniNalog = fView.FokusiraniRadniNalog;
            if (radniNalog == null) return;
            var index = fRadniNalozi.IndexOf(radniNalog);
            switch (tipAktivnosti)
            {
                case "NT":
                    try
                    {
                        //fRadniNalozi.RaiseListChangedEvents = false;
                        var radniListUrednika = radniNalog as Core.Model.RadniListUrednika;
                        if (radniListUrednika != null)
                        {
                            var novi = new Core.Model.RadniListNovinara()
                            {
                                Datum = radniNalog.Datum, 
                                PublikacijaID = radniNalog.PublikacijaID, 
                                RubrikaID = radniNalog.RubrikaID, 
                                RadnikID = radniNalog.RadnikID
                            };
                            fRadniNalozi.Insert(index, novi);
                            fRadniNalozi.RemoveAt(index + 1);
                            fView.FokusirajStavku(novi);
                        }
                    }
                    finally
                    {
                        //fRadniNalozi.RaiseListChangedEvents = true;
                    }
                    break;
                case "UT":
                    try
                    {
                        //fRadniNalozi.RaiseListChangedEvents = false;
                        var radniListNovinara = radniNalog as Core.Model.RadniListNovinara;
                        if (radniListNovinara != null)
                        {
                            var novi = new Core.Model.RadniListUrednika()
                            {
                                Datum = radniNalog.Datum, 
                                PublikacijaID = radniNalog.PublikacijaID, 
                                RubrikaID = radniNalog.RubrikaID, 
                                RadnikID = radniNalog.RadnikID
                            };
                            fRadniNalozi.Insert(index, novi);
                            fRadniNalozi.RemoveAt(index + 1);
                            fView.FokusirajStavku(novi);
                        }
                    }
                    finally
                    {
                        //fRadniNalozi.RaiseListChangedEvents = true;
                    }
                    break;
            }
        }

        public void IzabranSledeciNalog(object nalog)
        {
            PokusajDaSacuvas();
            fTekuciRadniList = (Core.Model.RadniNalog) nalog;
            fView.OmoguciIzborTipaAktivnosti(fTekuciRadniList.JeNovi);
            if (nalog is Core.Model.RadniListNovinara)
            {
                var rln = nalog as Core.Model.RadniListNovinara;
                fView.PostaviRadniListNovinara(rln);
                if (fPrikazRadnogLista != PrikazRadnogLista.RadniListNovinara)
                {
                    fView.PrikaziRadniListNovinara(rln);
                    fPrikazRadnogLista = PrikazRadnogLista.RadniListNovinara;
                }
                fView.IzaberiTipAktivnosti("NT");
            }
            else if (nalog is Core.Model.RadniListUrednika)
            {
                var rlu = nalog as Core.Model.RadniListUrednika;
                fView.PostaviRadniListUrednika(rlu);
                if (fPrikazRadnogLista != PrikazRadnogLista.RadniListUrednika)
                {
                    fView.PrikaziRadniListUrednika(rlu);
                    fPrikazRadnogLista = PrikazRadnogLista.RadniListUrednika;
                }
                fView.IzaberiTipAktivnosti("UT");
            }
        }

        private void PokusajDaSacuvas()
        {
            if (fTekuciRadniList != null && fTekuciRadniList.IsValid)
            {
                RepositoryFactory.RadniNaloziRepository.Add(fTekuciRadniList);
                RepositoryFactory.RadniNaloziRepository.Save();
            }
        }
    }
}