var RIS = RIS || {};

RIS.FotoArhiva = (function() {
    var izabraneSlike = [];

    var model = {
        pretrazi: _pretrazi,
        ocisti: _ocisti,
        showDialog: function () {
            pretragaSlikaPopup.Show();
        },
        hide: function () {
            pretragaSlikaPopup.Hide();
        },
        izabranaSlika: _izabranaSlika,
        otkazi: function () {
            naziv.SetValue('');
            tag.SetValue('');
            publikacijaID.SetValue(null);
            grupaMaterijalaID.SetValue(null);
        }
    };
    
    return model;

    function _pretrazi() {
        var params = {
            naziv: naziv.GetValue() || undefined,
            tag: tag.GetValue() || undefined,
            publikacija: publikacijaID.GetValue(),
            grupaMaterijala: grupaMaterijalaID.GetValue()
        };
        loader.Show();
        RIS.http.pretraziFotoArhivu(params, function(response) {
            var $rezultati = $("#rezultati");
            _ocisti();
            response.forEach(function (item) {
                var $img = $("<img alt=''  width='100' height='100' style='width: 100px; height: 100px' />");
                $img.click(function () {
                    var $this = $(this);
                    if ($this.hasClass('selected')) {
                        $this.removeClass('selected');
                        var id = $this.data("ID");
                        izabraneSlike.forEach(function (el, index) {
                            if (el.ID === id) {
                                izabraneSlike.splice(index, 1);
                            }
                        });
                    } else {
                        $this.addClass('selected');
                        id = $this.data("ID");
                        response.forEach(function (el) {
                            if (el.ID === id) {
                                izabraneSlike.push(el);
                            }
                        });
                    }
                });
                $img.attr('src', item.Thumbnail);
                $img.data('ID', item.ID);
                $rezultati.append($img);
            });
        }, function() {
            loader.Hide();
        });
    }

    function _ocisti() {
        var $rezultati = $("#rezultati");
        $rezultati.empty();
        izabraneSlike = [];
    }

    function _izabranaSlika() {
        $(document).trigger('izabraneSlike', [izabraneSlike]);
        model.hide();
    }

    
}());