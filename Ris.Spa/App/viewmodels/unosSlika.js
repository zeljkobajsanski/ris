define(['services/contentservice', 'services/logger'],
    function (contentservice, logger) {

        var viewModel = {
            fajlovi: [],
            naziv: ko.observable(),
            sacuvaj: function () {
                var that = this;
                contentservice.sacuvajMaterijal(this.naziv(), this.fajlovi)
                    .then(function () {
                        that.fajlovi = [];
                        that.naziv('');
                        $(".k-upload-files").remove();
                        logger.log("Podaci su uspešno sačuvani", null, null, true);
                    })
                    .fail(function(error) {
                        logger.logError(JSON.parse(error.responseText).Message, null, null, true);
                    });
            },
            
            obrisi: function(e) {
                
            },
            uspesanUpload: uspesanUpload
        };
        
        function uspesanUpload(e) {
            if (e.response != null && e.files.length == 1) {
                viewModel.fajlovi.push({ filename: e.response, extension: e.files[0].extension});
            }
        }

        return viewModel;
});