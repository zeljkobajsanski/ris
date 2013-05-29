define(['services/contentservice'],
    function (contentservice) {

    var viewModel = {
        slike: ko.observableArray(),
        naziv: ko.observable(),
        izabranaSlika: ko.observable(),
        izabranId: ko.observable(),
        isBusy: ko.observable(false),
        pretrazi: function() {
            var that = this;
            that.isBusy(true);
            $("#pics").isotope('remove', $(".pic"));
            contentservice.pretraziSlike(that.naziv()).then(function (response) {
                that.slike(response);
            }).done(function() {
                that.isBusy(false);
            });
        },
        afterAdd: function (el) {
            $("#pics").isotope('appended', $(el));
        },
        preuzmi: function () {
            $("#detaljanPrikaz").data('kendoWindow').close();
            var action = 'Content/Preuzmi/' + this.izabranId();
            window.open(action);
        },
        izaberi: izaberiSliku,
        isOpen: ko.observable(false),
        viewAttached: function() {
            $("#pics").isotope({
                layoutMode: 'cellsByRow',
                cellsByRow: {
                    columnWidth: 105,
                    rowHeight: 105
                }
            });
        }
    };

    function izaberiSliku() {
        viewModel.izabranaSlika(this.Putanja);
        viewModel.izabranId(this.ID);
        $("#detaljanPrikaz").data('kendoWindow').center();
        viewModel.isOpen(true);
    }
    return viewModel;

});