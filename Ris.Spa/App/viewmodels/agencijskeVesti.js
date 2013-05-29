define(['services/dataservice', 'services/contentservice', 'services/logger'],
    function (dataservice, contentservice, logger) {
    var model = {
        datum: ko.observable(new Date()),
        agencija: ko.observable(),
        deoSadrzaja: ko.observable(),
        mailovi: ko.observableArray(),
        agencije: ko.observableArray(),
        sadrzaj: ko.observable(),
        isBusy: ko.observable(false),
        pojmoviPretrage: [],
        pretrazi: pretrazi,
        activate: activate,
        izabranEmail: izabranEmail
    };
    
    function activate() {
        dataservice.vratiAgencije().then(function(result) {
            model.agencije(result);
            result.forEach(function(item) {
                if (item.Default) model.agencija(item.ID);
            });

        });
    }
    
    function pretrazi() {
        model.sadrzaj('');
        model.isBusy(true);
        contentservice.pretraziEmailove(model.datum(), model.agencija(), model.deoSadrzaja())
            .then(function (result) {
                result.Vesti.forEach(function(item) {
                    item.Datum = moment(item.Datum).format('DD.MM.YYYY');
                });
                model.mailovi(result.Vesti);
                model.pojmoviPretrage = result.PojmoviPretrage;
                model.isBusy(false);
            });
    }

    function izabranEmail() {
        var selectedRow = this.select()[0];
        var email = this.dataItem(selectedRow);
        contentservice.vratiEmail(email.ID).then(function(result) {
            model.sadrzaj(result.Body);
            model.pojmoviPretrage.forEach(function (term) {
                $("#sadrzaj").highlight(term);
            });
            
        }).fail(function(error) {
            logger.logError("Neuspešno učitavanje vesti", null, null, true);
        });
    }
        
    return model;
});