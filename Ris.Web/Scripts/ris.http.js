RIS = RIS || {};

RIS.http = (function () {

    return {
        root: undefined,
        pretraziFotoArhivu: function(params, success, done) {
            $.get(this.root + "FotoArhiva/PretraziFotoArhivu", params, success).always(done);
        },
        posaljiNovinaru: function(data, success, done) {
            $.post(this.root + "Redakcija/PosaljiNovinaru", data, success).always(done);
        },
        posaljiUredniku: function (data, success, done) {
            $.post(this.root + "Redakcija/PosaljiUredniku", data, success).always(done);
        },
        posaljiLektoru: function (data, success, done) {
            $.post(this.root + "Redakcija/PosaljiLektoru", data, success).always(done);
        },
        posaljiUDTP: function (data, success, done) {
            $.post(this.root + "Redakcija/PosaljiUDTP", data, success).always(done);
        },
        obrisiTekst: function(id, success) {
            $.post(this.root + "Redakcija/ObrisiTekst", { id: id }, success);
        },
        ucitajUlogeKorisnika: function(data, success) {
            $.get(this.root + "KorisnickiNalozi/UcitajUlogeKorisnika", data, success);
        }
    };
})();
