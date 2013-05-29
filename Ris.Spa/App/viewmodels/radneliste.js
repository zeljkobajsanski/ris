define(['durandal/app', 'services/logger', 'services/dataservice', 'viewmodels/unosRadnogLista'],
    function (app, logger, dataservice, unos) {
        var model = {
            datum: null,
            publikacijaId: null,
            publikacija: null,
            radneListe: ko.observableArray([]),
            activate: function () {
                var that = this;
                app.showModal('viewmodels/izborRadneListe').then(function(result) {
                    that.datum = result.datum;
                    that.publikacijaId = result.izabranaPublikacija;
                    that.publikacija = result.nazivPublikacije;
                    ucitaj(that.datum, that.publikacijaId);
                });
            },
           kreirajNovu: function() {
               app.showModal(new unos({ ID: 0, Datum: this.datum, PublikacijaID: this.publikacijaId, Publikacija: this.publikacija, TipAktivnosti: 'Napisan tekst' }))
                  .then(function () { ucitaj(model.datum, model.publikacijaId); });
           },
           izabran: function() {
               var row = this.select()[0];
               var radniList = this.dataItem(row);
               app.showModal(new unos(radniList))
                  .then(function () { ucitaj(model.datum, model.publikacijaId); });
           }
        };
        
        var ucitaj = function (datum, publikacija) {
            dataservice.vratiRadneListe(moment(datum).format(), publikacija).then(function (radneListe) {
                radneListe.forEach(function (radnaLista) {
                    radnaLista.Datum = moment(radnaLista.Datum).format('L');
                });
                model.radneListe(radneListe);
                
            });
        };

        return model;
    });