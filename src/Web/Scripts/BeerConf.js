/// <reference path="jquery-1.6.2.js" />
/// <reference path="jquery-ui-1.8.14.js" />

(function ($) {
    function replaceDashWithUpperCase(str) {
        return str.split(/\-([a-z])/).map(function (x, i) { return (i % 2 == 1) ? x.toUpperCase() : x; }).join('');
    };
    function getOptions(selector) {
        var data = $(selector).data();
        var options = {};
        for (var k in data) {
            options[replaceDashWithUpperCase(k)] = data[k];
        }
    }
    $(function () {
        $('[role=datepicker]').each(function () {
            $(this).datepicker(getOptions(this));
        });
        $('[role=datetimepicker]').each(function () {
            var format = function (val) {
                if (val < 10)
                    return '0' + val.toString();
                return val.toString();
            };

            var e = $(this);
            var values = e.val().split(/[ :]/);
            var date = $('<input />')
                .val(values[0])
                .datepicker(getOptions(this));

            var hour = $('<select>');
            var i;
            for (i = 0; i < 24; i++) {
                hour.append($('<option />', { value: format(i), text: format(i) }));
            }
            hour.val(values[1]);

            var minute = $('<select>');
            for (i = 0; i < 60; i += 5) {
                minute.append($('<option />', { value: format(i), text: format(i) }));
            }
            minute.val((Math.ceil(parseInt(values[2]) / 5) * 5) || 0);

            $().add(date).add(hour).add(minute)
                .change(function () {
                    e.val(date.val() + ' ' + hour.val() + ':' + minute.val());
                })
                .appendTo(e.parent());

            e.get(0).type = 'hidden'; //HACK!
        });
    });
})(jQuery);

