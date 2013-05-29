using System;
using System.Collections.Generic;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Win.Alerts;

namespace Rs.Dnevnik.Ris.Win.Modules.RadniNalog
{
    public interface IView : Modules.IView
    {
        void PrikaziDijalogIzbora();
        void Enable(bool enable);
        void PrikaziRadneNaloge(IList<Core.Model.RadniNalog> radniNalozi);
        void UcitajRubrike(int idPublikacije);
        void FokusirajStavku(Core.Model.RadniNalog stavka);
        Core.Model.RadniNalog FokusiraniRadniNalog { get; }
        void PostaviTipoveAktivnosti(TipAktivnosti[] tipoviAktivnosti);
        void PrikaziRadniListNovinara(Core.Model.RadniListNovinara radniListNovinara);
        void IzaberiTipAktivnosti(string tipAktivnosti);
        void PrikaziRadniListUrednika(Core.Model.RadniListUrednika radniListUrednika);
        void OmoguciIzborTipaAktivnosti(bool omoguci);
        void PostaviRadniListNovinara(Core.Model.RadniListNovinara radniListNovinara);
        void PostaviRadniListUrednika(Core.Model.RadniListUrednika radniListUrednika);
    }
}