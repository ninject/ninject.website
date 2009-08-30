(function($) {

	$.fn.extend({
		hoverFade: function(delay) {
			delay = delay || 500;
			return this.each(function() {
				var $self = $(this);
				$self.append("<span class='hover'></span>").each(function() {
					var $hover = $("> span.hover", this);
					$hover.css("opacity", 0).css("background-image", $(this).css("background-image"));
					$(this).hover(function() {
						$hover.stop().fadeTo(delay, 1);
					}, function() {
						$hover.stop().fadeTo(delay, 0);
					});
				});
				return this;
			});
		}
	});
	
	$(function() {
		$("a").filter(function() { return this.hostname && this.hostname !== location.hostname }).attr("rel", "external");
		$("a[rel='external']").addClass("external").attr("target", "_blank");
	});

})(jQuery);