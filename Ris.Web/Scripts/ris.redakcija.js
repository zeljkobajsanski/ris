var RIS = RIS || {};

RIS.Redakcija = (function Redakcija() {
    $(function () {
        $(".delete").click(obrisiSliku);
        $("#tekstForm").validate({
            rules: {
                'Tekst.Naslov': { required: true },
                'Tekst.PublikacijaID': { required: true },
                'Tekst.RubrikaID': { required: true },
            },
            messages: {
                'Tekst.Naslov': { required: 'Naslov nije unet' },
                'Tekst.PublikacijaID': {required: 'Publikacija nije izabrana'},
                'Tekst.RubrikaID': {required: 'Rubrika nije izabrana'}
            }
        });
    });

    $(document).bind('izabraneSlike', function(e, izabraneSlike) {
        var brojSlika = $(".slikaWrapper").size();
        izabraneSlike.forEach(function (materijal, index) {
            var wrapper = $("<div class='slikaWrapper'></div>");
            var $input = $("<input type='hidden' class='materijalID' />");
            $input.attr('name', 'Tekst.Materijali[' + (brojSlika + index) + '].ID');
            $input.attr('id', 'Tekst_Materijali_' + (brojSlika + index) + '__ID');
            $input.val(materijal.ID);
            wrapper.append($input);
            var putanja = $("<input type='hidden' class='materijalPutanja' />");
            putanja.attr('name', 'Tekst.Materijali[' + (brojSlika + index) + '].Putanja');
            putanja.attr('id', 'Tekst_Materijali_' + (brojSlika + index) + '__Putanja');
            putanja.val(materijal.Putanja);
            wrapper.append(putanja);
            var thumbnail = $("<input type='hidden' class='materijalThumbnail' />");
            thumbnail.attr('name', 'Tekst.Materijali[' + (brojSlika + index) + '].Thumbnail');
            thumbnail.attr('id', 'Tekst_Materijali_' + (brojSlika + index) + '__Thumbnail');
            thumbnail.val(materijal.Thumbnail);
            wrapper.append(thumbnail);
            var img = $("<img alt='' width=100 height=100 class='slika' />");
            img.attr('src', materijal.Thumbnail);
            img.data('id', materijal.ID);
            img.click(RIS.Redakcija.preuzmiSliku);
            wrapper.append(img);
            var $delete = $("<img src='/Content/images/trash_16x16.png' alt='' title='Obriši' />");
            $delete.click(obrisiSliku);
            wrapper.append($delete);
            $("#thumbnails").append(wrapper);
        });
    });
    
    var izabranaPublikacija;

    var model = {
        obrisiSliku: obrisiSliku,
        preuzmiSliku: function() {
            var that = $(this);
            var id = that.data('id');
            window.open('/FotoArhiva/Preuzmi/' + id, "_blank");
        },
        beginUcitajRubrike: function(s, e) {
            e.customArgs['idPublikacije'] = izabranaPublikacija;
        },
        promenjenaPublikacija: function (s, e) {
            cmbRubrike.SetValue(null);
            izabranaPublikacija = s.GetValue();
            if (!cmbRubrike.InCallback()) {
                cmbRubrike.PerformCallback();
            }
        },
        promenjenTekst: function() {
            var tekst = $("<div/>").html(Html.GetHtml()).text();
            $("#brojKaraktera").text(tekst.length);
            var brojReci = tekst.split(" ").length;
            $("#brojReci").text(brojReci);
        },
        controllerPath: undefined,
        posaljiNovinaru: _posaljiNovinaru,
        posaljiUredniku: _posaljiUredniku,
        posaljiLektoru: _posaljiLektoru,
        posaljiUDTP: _posaljiUDTP,
        prikaziTekstove: _prikaziTekstove,
        pregledTekstovaBeginCallback: _pregledTekstovaBeginCallback,
        obrisiTekst: _obrisiTekst,
        komentariPopupShown: _komentariPopupShown,
        prikaziKomentare: function () {
            komentariPopup.Show();
            
        }
    };

    function obrisiSliku() {
        $(this).parent().remove();
        $(".materijalID").each(function (ix, el) {
            $(el).attr('name', 'Tekst.Materijali[' + ix + '].ID');
            $(el).attr('id', 'Tekst_Materijali_' + ix + '__ID');
        });
        $(".materijalPutanja").each(function (ix, el) {
            $(el).attr('name', 'Tekst.Materijali[' + ix + '].Putanja');
            $(el).attr('id', 'Tekst_Materijali_' + ix + '__Putanja');
        });
        $(".materijalThumbnail").each(function (ix, el) {
            $(el).attr('name', 'Tekst.Materijali[' + ix + '].Thumbnail');
            $(el).attr('id', 'Tekst_Materijali_' + ix + '__Thumbnail');
        });
    }
    
    function _posaljiNovinaru() {
        if (confirm('Da li želite da pošaljete komentar?')) {
            model.prikaziKomentare();
            return;
        }
        loader1.Show();
        var data = {
            idTeksta: $("#Tekst_ID").val()  
        };
        RIS.http.posaljiNovinaru(data, function(redirectTo) {
            window.open(redirectTo, '_self');
        }, _hideLoader);
    }
    
    function _posaljiUredniku() {
        if (confirm('Da li želite da pošaljete komentar?')) {
            model.prikaziKomentare();
            return;
        }
        loader1.Show();
        var data = {
            idTeksta: $("#Tekst_ID").val()
        };
        RIS.http.posaljiUredniku(data, function(redirectTo) {
            window.open(redirectTo, '_self');
        }, _hideLoader);
    }
    
    function _posaljiLektoru() {
        if (confirm('Da li želite da pošaljete komentar?')) {
            model.prikaziKomentare();
            return;
        }
        loader1.Show();
        var data = {
            idTeksta: $("#Tekst_ID").val()
        };
        RIS.http.posaljiLektoru(data, function(redirectTo) {
            window.open(redirectTo, '_self');
        }, _hideLoader);
    }
    
    function _posaljiUDTP() {
        loader1.Show();
        var data = {
            idTeksta: $("#Tekst_ID").val()
        };
        RIS.http.posaljiUDTP(data, function (redirectTo) {
            window.open(redirectTo, '_self');
        }, _hideLoader);
    }
    
    function _hideLoader() {
        loader1.Hide();
    }

    function _prikaziTekstove() {
        if (!gvPregledTekstova.InCallback()) {
            gvPregledTekstova.PerformCallback();
        }
    }

    function _pregledTekstovaBeginCallback(s, e) {
        e.customArgs['idPublikacije'] = cmbPublikacije.GetValue();
        e.customArgs['idRubrike'] = cmbRubrike.GetValue();
        var datumValue = datum.GetValue();
        if (datumValue) {
            datumValue = moment(datumValue).format('DD-MM-YYYY');
        }
        e.customArgs['datum'] = datumValue;
        
    }
    
    function _obrisiTekst(id) {
        if (confirm('Da li želite da obrišete izabrani tekst?')) {
            RIS.http.obrisiTekst(id, _prikaziTekstove);
        }
        return false;
    }
    
    function _komentariPopupShown() {
        if (!komentariPanel.InCallback()) {
            komentariPanel.PerformCallback();
        }
    }

    return model;
})();