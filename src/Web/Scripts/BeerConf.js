/// <reference path="jquery-1.7.js" />
/// <reference path="jquery-ui-1.8.16.js" />

(function ($) {
    $(function () {
        $('[role=datepicker]').each(function () {
            var self = $(this);
            self.datepicker(self.data());
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
                .datepicker(e.data());

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

