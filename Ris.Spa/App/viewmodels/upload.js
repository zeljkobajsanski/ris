define(function() {
    var model = {
        showList: ko.observable(true),
        complete: onComplete,
        upload: function(e) {
            e.data = {name: "XXX"};
        }
    };

    function onComplete() {
        model.showList(false);
    }
    return model;
});