var RIS = RIS || {};

$(function() {
    $("#izborForm").submit(RIS.RadniList.izaberi);
    $("#radniListNovinara").hide();
    $("#radniListUrendika").hide();
});

RIS.RadniList = (function() {

    return {
        prikaziIzbor: function() {
            izborPopup.Show();
        },
        izabranTipTeksta:  _izabranTipTeksta,
        izabranRadniList: _izabranRadniList
    };

    function _izabranRadniList(s) {
        s.GetRowValues(s.GetFocusedRowIndex(), "ID;TipAktivnosti;RadnikID;PublikacijaID;Datum;BrojStranice;Stubaca;Centimetara", function (values) {
            cmbTipAktivnosti.SetValue(values[1]);
            _izabranTipTeksta();
            cbRadnici.SetValue(values[2]);
            cmbPublikacija.SetValue(values[3]);
            dateEditDatum.SetValue(values[4]);
            spinBrojStranice.SetValue(values[5]);
            spinStubaca.SetValue(values[6]);
            spinCentimetara.SetValue(values[7]);
        });
    }
    
    function _izabranTipTeksta() {
        var cmb = cmbTipAktivnosti;
        var tipAktivnosti = cmb.GetValue();
        switch (tipAktivnosti) {
            case 'NT':
                $("#radniListNovinara").show();
                break;
            case "UT":
                $("#radniListNovinara").hide();
                break;
            default: break;
        }
    }
}());