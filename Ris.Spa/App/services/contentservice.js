define(['durandal/http'], function(http) {

    return {
        pretraziEmailove: function (datum, agencija, deoSadrzaja) {
            var params = {
                idAgencije: null,
                deoSadrzaja: null,
                datum: null
            };
            if (agencija) {
                params.idAgencije = agencija;
            }
            if (deoSadrzaja) {
                params.deoSadrzaja = deoSadrzaja;
            }
            if (datum != null) {
                params.datum = moment(datum).format();
            }
            return http.get('api/Data/VratiAgencijskeVesti', params);
        },
        vratiEmail: function(id) {
            return http.get('api/Data/VratiAgencijskuVest', { id: id });
        },
        //sacuvajMaterijal: function(fajlovi, success, error) {
        //    $.ajax({
        //        url: 'api/Data/SacuvajMaterijal',
        //        data: { naziv: 'Naziv' },
        //        type: 'POST',
        //        dataType: 'json',
        //        contentType: 'application/json',
        //        //traditional: true
        //    }).done(success).fail(error);
        //}
        sacuvajMaterijal: function(naziv, fajlovi) {
            return http.post("api/Data/SacuvajMaterijal", { 'naziv': naziv, 'slike': fajlovi });
        },
        pretraziSlike: function (naziv) {
            var params = {
                naziv: naziv || ''
            };
            
            return http.get("api/Data/PretraziSlike", params);
        },
        preuzmiMaterijal: function() {
            return http.get('api/Data/PreuzmiMaterijal');
        }
    };
})