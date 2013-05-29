toastr.options.positionClass = 'toast-bottom-right';

var RIS = window.RIS || {};

RIS.showInfo = function(message) {
    toastr.info(message, "RIS");
};

RIS.showSuccess = function (message) {
    toastr.success(message, "RIS");
};

RIS.showError = function (message) {
    toastr.error(message, "RIS");
};

