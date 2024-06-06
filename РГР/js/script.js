(function($) { "use strict";

	$('body').on('mouseenter mouseleave','.nav-item',function(e){
			if ($(window).width() > 750) {
				var _d=$(e.target).closest('.nav-item');_d.addClass('show');
				setTimeout(function(){
				_d[_d.is(':hover')?'addClass':'removeClass']('show');
				},1);
			}
	});		

})(jQuery);

function update() {
	let clock = document.getElementById('clock');
	let date = new Date();
	let hours = date.getHours();
	if (hours < 10) hours = '0' + hours;
	clock.children[0].innerHTML = hours;
  
	let minutes = date.getMinutes();
	if (minutes < 10) minutes = '0' + minutes;
	clock.children[1].innerHTML = minutes;
  
	let seconds = date.getSeconds();
	if (seconds < 10) seconds = '0' + seconds;
	clock.children[2].innerHTML = seconds;
}
  
let timerId;

function clockStart() {
  timerId = setInterval(update, 1000);
  update();
}

clockStart()