/// <reference path="jquery-1.6.2.js" />
/// <reference path="jquery-ui-1.8.14.js" />

(function ($) {
	function replaceDashWithUpperCase(str) {
		return str.split(/\-([a-z])/).map(function (x, i) { return (i % 2 == 1) ? x.toUpperCase() : x; }).join('');
	};

	$(function () {
		$('[role=datepicker]').each(function () {
			var data = $(this).data();
			var options = {};
			for (var k in data) {
				options[replaceDashWithUpperCase(k)] = data[k];
			}
			$(this).datepicker(options);
		});
	});
})(jQuery);

