/// <reference path="~/app/durandal/http.js" />
define(['durandal/http'],
    function (http) {

    return {
      vratiSvePublikacije: function() {
          return http.get('api/Data/VratiPublikacije');
      },
      vratiRadneListe: function(datum, publikacija) {
          return http.get('api/Data/VratiRadneListe', { datum: datum, idPublikacije: publikacija });
      },
      unosRadnogLista: function(idPublikacije) {
          return http.get('api/Data/UnosRadnogLista', { idPublikacije: idPublikacije });
      },
      sacuvajRadniList: function(radniList) {
          return http.post('api/Data/SacuvajRadniList', radniList);
      },
      obrisiRadnuListu: function(id) {
          return http.post('api/Data/ObrisiRadnuListu', { ID: id });
      },
      vratiAgencije: function() {
          return http.get('api/Data/VratiAgencije');
      }
    };
});