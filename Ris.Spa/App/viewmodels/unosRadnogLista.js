define(['services/dataservice', 'services/logger'], function(dataservice, logger) {

    var model = function(radniList) {
        this.id = ko.observable(radniList.ID);
        this.tipAktivnosti = ko.observable(radniList.TipAktivnosti);
        this.datum = radniList.Datum;
        this.publikacijaId = radniList.PublikacijaID,
        this.publikacija = radniList.Publikacija;
        this.rubrika = ko.observable(),
        this.radnik = ko.observable(),
        this.rubrike = ko.observableArray([]),
        this.radnici = ko.observableArray([]),
        this.tipoviAktivnosti = ko.observableArray([]);
        this.tipoviTeksta = ko.observableArray();
        this.tipTeksta = ko.observable();
        this.naslov = ko.observable(radniList.Naslov);
        this.brojStranice = ko.observable(radniList.BrojStranice);
        this.stubaca = ko.observable(radniList.Stubaca);
        this.centimetara = ko.observable(radniList.Centimetara);
        this.ocena = ko.observable();
        this.ocene = ko.observableArray();
        this.napomena = ko.observable(radniList.Napomena);
        this.kopiraj = function() {
            this.id(0);
            this.tipTeksta(null);
            this.naslov(null);
            this.brojStranice(0);
            this.stubaca(null);
            this.centimetara(null);
            this.ocena(null);
        },
        this.obrisi = function () {
            var that = this;
            dataservice.obrisiRadnuListu(this.id).then(function() {
                that.modal.close();
            });
        },
        this.activate = function () {
            var that = this;
            dataservice.unosRadnogLista(radniList.PublikacijaID).then(function (response) {
                that.rubrike(response.Rubrike);
                that.radnici(response.Radnici);
                that.rubrika(radniList.RubrikaID);
                that.radnik(radniList.RadnikID);
                that.tipoviAktivnosti(response.TipoviAktivnosti);
                that.tipAktivnosti(radniList.TipAktivnosti);
                that.ocene(response.Ocene);
                that.ocena(radniList.OcenaID);
                that.tipoviTeksta(response.TipoviTeksta);
                that.tipTeksta(radniList.TipTekstaID);
            });
        };
    };
    model.prototype.sacuvaj = function () {
        var that = this;
        dataservice.sacuvajRadniList({
            ID: this.id,
            TipAktivnosti: this.tipAktivnosti(),
            Datum: this.datum,
            RadnikID: this.radnik(),
            RubrikaID: this.rubrika(),
            PublikacijaID: this.publikacijaId,
            OcenaID: this.ocena(),
            Naslov: this.naslov(),
            BrojStranice: this.brojStranice(),
            Stubaca: this.stubaca(),
            Centimetara: this.centimetara(),
            Napomena: this.napomena(),
            TipTekstaID: this.tipTeksta()
        }).then(function() {
            that.modal.close();
        }).fail(function (error) {
            var errorObj = $.parseJSON(error.responseText);
            var errorString = errorObj.ExceptionMessage.replace(/\n/g, '<br />');
            logger.logError(errorString, null, null, true);
        });            
        
        
    };
    model.prototype.otkazi = function() {
        this.modal.close();
    };
    
    return model;
});