using System;
using System.Collections.Generic;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.Win.Modules.IzvestajRadnihNalog
{
    public interface IIzvestajPoDatumuView : IView
    {
        void PostaviOdDatuma(DateTime odDatuma);
        void PostaviDoDatuma(DateTime doDatuma);
        void PrikaziIzvestaj(ICollection<OstvarenjejRadnogNaloga> izvestaj);
    }
}