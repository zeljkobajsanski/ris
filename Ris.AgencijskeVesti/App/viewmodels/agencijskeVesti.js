define(function(require) {
    var http = require('durandal/http'),
        vesti = ko.observableArray([]),
        agencije = ko.observableArray([]),
        agencija = ko.observable(),
        naslov = ko.observable(),
        odDatuma = ko.observable(new Date());
    var ucitaj = function() {
        return http.get('Data/VratiAgencijskeVesti', {idAgencije: agencija()}).then(function (response) {
            agencije(response.Agencije);
            vesti(response.Vesti);
        });
    };
    var vest = ko.observable();
    return {
        vesti: vesti,
        agencije: agencije,
        agencija: agencija,
        odDatuma: odDatuma,
        activate: ucitaj,
        refresh: ucitaj,
        naslov: naslov,
        vest: vest,
        izabran: function() {
            var row = this.select();
            var dataItem = this.dataItem(row);
            naslov(dataItem.Naslov);
            vest(dataItem.Body);
        }
    };
});