define(['services/dataservice'],
    function (dataservice) {
    var model = {
        datum : ko.observable(new Date()),
        publikacije : ko.observableArray([]),
        izabranaPublikacija: ko.observable(),
        potvrdi: function () {
            var that = this;
            this.modal.close({
                datum: that.datum(),
                izabranaPublikacija: that.izabranaPublikacija(),
                nazivPublikacije: that.publikacije().filter(function (publikacija) { return publikacija.ID == that.izabranaPublikacija(); })[0].Naziv
            });
        },
        canDeactivate: function() {
            return this.datum() !== undefined && this.izabranaPublikacija() !== undefined;
        },
        activate: function () {
            var that = this;
            dataservice.vratiSvePublikacije().then(function(response) {
                that.publikacije(response);
                
            });
        } 
    };

    return model;
});