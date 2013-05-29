var RIS = RIS || {};

RIS.KorisnickiNalozi = (function () {

    $(function() {
        
    });
    var idKorisnika;
    
    var model = {
        izabranNalog: _izabranNalog,
        callbackPanelBeginCallback: _callbackPanelBeginCallback,
        //sacuvaj: _sacuvaj,
        callbackPanelEndCallback: function() {
            $("form").validate({
                rules: {
                    'KorisnickiNalog.KorisnickoIme': { required: true },
                    'KorisnickiNalog.RadnikID': { min: 1 },
                },
                messages: {
                    'KorisnickiNalog.KorisnickoIme': { required: 'Korisničko ime nije uneto' },
                    'KorisnickiNalog.RadnikID': { min: 'Radnik nije izabran' }
                }
            });
            if ($("#idKorisnika").val() == 0) {
                korisnickoIme.Focus();
                UlogeRadnika.SetVisible(false);
                UlogeLabel.SetVisible(false);
            } else {
                UlogeRadnika.SetVisible(true);
                UlogeLabel.SetVisible(true);
            }
        },
        noviNalog: function() {
            idKorisnika = undefined;
            if (!callbackPanel.InCallback()) {
                callbackPanel.PerformCallback();
            }
        }
    };
    return model;

    function _izabranNalog(s, e) {
        
        idKorisnika = s.GetRowKey(s.GetFocusedRowIndex());
        if (!callbackPanel.InCallback()) {
            callbackPanel.PerformCallback();
        }
    }

    function _callbackPanelBeginCallback(s, e) {
        e.customArgs['id'] = idKorisnika;
    }
    
}());
