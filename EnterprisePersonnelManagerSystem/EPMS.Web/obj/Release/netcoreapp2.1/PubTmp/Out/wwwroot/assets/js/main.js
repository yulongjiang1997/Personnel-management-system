

// make console.log safe to use

window.console||(console={log:function(){}});

(function(){
	       window.alert = function(name){
	var iframe = document.createElement("IFRAME");
	iframe.style.display="none";
	iframe.setAttribute("src", 'data:text/plain');
	document.documentElement.appendChild(iframe);
	window.frames[0].window.alert(name);
	iframe.parentNode.removeChild(iframe);
	}
	  })();


var ModalHelper = (function(bodyCls) {
  var scrollTop;
  return {
    afterOpen: function() {
      scrollTop = document.scrollingElement.scrollTop;
      document.body.classList.add(bodyCls);
      document.body.style.top = -scrollTop + 'px';
    },
    beforeClose: function() {
      document.body.classList.remove(bodyCls);
      // scrollTop lost after set position:fixed, restore it back.
      document.scrollingElement.scrollTop = scrollTop;
    }
  };
})('noscroll');


/* Modal js  */ 


!(function($) {
	$.alert = {
		alert: function(title, content, width,callback) {
			if(title == '') {title = 'Message'};
			if(width == '') {width = '300'};
			// content = content.replace(/</g, '&lt;').replace(/>/g, '&gt;');
			$.alert._show('alert', title, content, width,function(res){
				if(callback) {callback(res)}
			});
		},
		info: function(title, content, width,callback) {
			if(title == '') {title = 'Message'};
			if(width == '') {width = '300'};
			content = content.replace(/</g, '&lt;').replace(/>/g, '&gt;');
			$.alert._show('info', title, content, width,function(res){
				if(callback) {callback(res)}
			});
		},
		confirm: function(title, content, width, callback) {
			if(title =='') {title = 'Message'};
			if(width == '') {width = '300'};
			// content = content.replace(/</g, '&lt;').replace(/>/g, '&gt;');
			$.alert._show('confirm', title, content, width, function(res) {
				if(callback) {callback(res)}
			})
		},
		confirmWithHTML:function({title="Tip",width="300",content,callback}){
			$.alert._show('confirm',title,content,width,function(res){
				if(callback){callback(res)}
			})
		},
		prompt: function(title,content,width,callback){
			if(title =='') {title = 'Message'};
			if(width == '') {width = '300'};
			content = content.replace(/</g, '&lt;').replace(/>/g, '&gt;');
			// content = '<textarea class="modal_text">'+ content +'</textarea>'
			$.alert._show('prompt', title, content, width, function(res) {
				if(callback) {callback(res)}
			})
		},
		iframe: function(title,src,width,height){
			if(title =='') {title = 'Messag'};
			if(width == '') {width = '100%'};
			var content = '<iframe class="modal_iframe" src="'+src +'"width="'+ width+'"height="'+height+'"></iframe>'
			$.alert._show('iframe', title, content)
		},
		_show: function(type, title, content, width, callback) {
			var basicHtml = '<div class="modalMask" data-open="false"> <div class="modalWindow"> <div class="modal_header"> ' +
				'<h3 class="modal_title">' + title + '</h3> <button class="modal_close btn"><span class="icon24 minia-icon-close">X</span></button> </div>' +
				'<div class="modal_body">' + content + '</div>' +
				'<div class="modal_footer"> </div> </div> </div>';
				if ($(".modalMask").length != 0) {
					return false
				}
			$('body').append(basicHtml);
			// $('.modalMask').attr('data-open', 'true');
			setTimeout(function() {$('.modalMask').attr('data-open', 'true');}, 300);
			$('.modal_close').click(function() {
				// store.state.clicked = false
				$.alert._close();
				//callback(false)
			});
			ModalHelper.afterOpen()
			// $('body').addClass('noscroll')
			switch(type) {
				case 'alert':
					$('.modalWindow').css('max-width', width + 'px')
					// $('.modal_footer').html('<div class="btn modal_ok">OK</div>')
					$('.modal_footer').html(`<div class="form-group">
					<div class="col-lg-offset-2" style="padding-left:15px">
						<button type="submit" id="confirm" class="btn btn-default marginR10">OK</button>
						<button type="button" id="cancel" class="btn btn-danger">Cancel</button>
					</div>
				</div>`)
					$('.modal_ok').click(function() {
						$.alert._close()
					})
					break;


				case 'info' :

				$('.modalWindow').css('max-width', width + 'px')
				$('.modal_footer').html('<div class="btn modal_ok">OK</div>')
				$('.modal_ok').click(function() {
					$.alert._close()
				})
				break;



				case 'confirm':
					$('.modalWindow').css('max-width', width + 'px')
					// $('.modal_footer').html('<div class="btn modal_cancel">Cancel</div><div class="btn modal_ok">OK</div>')
					$('.modal_ok').click(function() {
						$.alert._close();
						callback(true);
					})
					$('.modal_cancel').click(function() {
						$.alert._close();
						callback(false);
					})
					break;
				case 'prompt':
					$('.modalWindow').css('max-width', width + 'px')
					$('.modal_footer').html('<div class="btn modal_cancel">Cancel</div><div class="btn modal_ok">OK</div>')
					$('.modal_ok').click(function() {
						$.alert._close();
						callback(true);
					})
					$('.modal_cancel').click(function() {
						$.alert._close();
						callback(false);
					})
					break;
				case 'iframe':
					// $('.modal_footer').html('<div class="btn modal_cancel">Cancel</div><div class="btn modal_ok">OK</div>')
					$('.modal_ok').click(function() {
						$.alert._close();
						callback(true);
					})
					$('.modal_cancel').click(function() {
						$.alert._close();
						callback(false);
					})
					break;
				default:
					break;
			}
		},
		_close: function() {
			// store.state.clicked = false
			$('.modalMask').attr('data-open', 'false');
			// $('body').removeClass('noscroll')
			ModalHelper.beforeClose('noscroll')
			setTimeout(function() {$('.modalMask').remove();}, 300);
		}
	};
	//标题、内容、宽度
	$.jAlert = function(title, content, width){$.alert.alert(title, content, width)};
	$.jInfo = function(title, content, width){$.alert.info(title, content, width)};
	$.jConfirm = function(title, content, width, callback){$.alert.confirm(title, content, width, callback)};
	$.jprompt = function(title,content,width,callback){$.alert.prompt(title,content,width,callback)};
	$.jiframe = function(title,src,width,height){$.alert.iframe(title,src,width,height)};
})(jQuery);















//------------- Options for Supr - admin tempalte -------------//
var supr_Options = {
	fixedWidth: false, //activate fixed version with true
	rtl:false //activate rtl version with true
}

//------------- Modernizr -------------//
//load some plugins only if is needed
Modernizr.load({
  test: Modernizr.placeholder,
  nope: '../plugins/forms/placeholder/jquery.placeholder.min.js',
  complete: function () {
	//------------- placeholder fallback  -------------//
	$('input[placeholder], textarea[placeholder]').placeholder();
  }
});
Modernizr.load({
  test: Modernizr.touch,
  yep: ['../plugins/fix/ios-fix/ios-orientationchange-fix.js', '../plugins/fix/touch-punch/jquery.ui.touch-punch.min.js']
});

//window resize events
$(window).resize(function(){
	//get the window size
	var wsize =  $(window).width();
	if (wsize > 980 ) {
		$('.shortcuts.hided').removeClass('hided').attr("style","");
		$('.sidenav.hided').removeClass('hided').attr("style","");
	}

	var size ="Window size is:" + $(window).width();
	//console.log(size);
});

$(window).load(function(){
	var wheight = $(window).height();
	$('#sidebar.scrolled').css('height', wheight-63+'px');
});

// document ready function
$(document).ready(function(){ 	

	//make template fixed width
	if(supr_Options.fixedWidth) {
		$('body').addClass('fixedWidth');
		$('#header').addClass('container');
		$('#wrapper').addClass('container');
	}

	//rtl version
	if(supr_Options.rtl) {
		localStorage.setItem('rtl', 1);
		$('#bootstrap').attr('href', '../css/bootstrap/bootstrap.rtl.min.css');
		$('#bootstrap-responsive').attr('href', '../css/bootstrap/bootstrap-responsive.rtl.min.css');
		$('body').addClass('rtl');
		if(!$('#content-two').length){
			$('#sidebar').attr('id', 'sidebar-right');
			$('#sidebarbg').attr('id', 'sidebarbg-right');
			$('.collapseBtn').addClass('rightbar').removeClass('leftbar');
			$('#content').attr('id', 'content-one');
		}
	} else {localStorage.setItem('rtl', 0);}
	
  	//Disable certain links
    $('a[href^=#]').click(function (e) {
      e.preventDefault()
    })

    $('.search-btn').addClass('nostyle');//tell uniform to not style this element
 
	//------------- Navigation -------------//

	var mainNav = $('.mainnav>ul>li');
	mainNav.find('ul').siblings().addClass('hasUl').append('<span class="hasDrop icon16 icomoon-icon-arrow-down-2"></span>');
	var mainNavLink = mainNav.find('a').not('.sub a');
	var mainNavLinkAll = mainNav.find('a');
	var mainNavSubLink = mainNav.find('.sub a').not('.sub li');
	var mainNavCurrent = mainNav.find('a.current');

	//add hasSub to first element
	if(mainNavLink.hasClass('hasUl')) {
		$(this).closest('li').addClass('hasSub');
	}
	
	/*Auto current system in main navigation */
	var domain = document.domain;
	var folder ='';//if you put site in folder not in main domain you need to specify it. example http://www.host.com/folder/site
	var absoluteUrl = 0; //put value of 1 if use absolute path links. example http://www.host.com/dashboard instead of /dashboard

	function setCurrentClass(mainNavLinkAll, url) {
		mainNavLinkAll.each(function(index) {
			//convert href to array and get last element
			var href= $(this).attr('href');

			if(href == url) {
				//set new current class
				$(this).addClass('current');

				parents = $(this).parentsUntil('li.hasSub');
				parents.each(function() {
					if($(this).hasClass('sub')) {
						//its a part of sub menu need to expand this menu
						$(this).prev('a.hasUl').addClass('drop');
						$(this).addClass('expand');
					} 
				});
			}
		});
	}


	if(domain === '') {
		//domain not found looks like is in testing phase
		var pageUrl = window.location.pathname.split( '/' );
		var winLoc = pageUrl.pop(); // get last item
		setCurrentClass(mainNavLinkAll, winLoc);

	} else {
		if(absoluteUrl === 0) {
			//absolute url is disabled
			var afterDomain = window.location.pathname;
			if(folder !='') {
				afterDomain = afterDomain.replace(folder + '/','');
			} else {
				afterDomain = afterDomain.replace('/','');
			}
			setCurrentClass(mainNavLinkAll, afterDomain);
		} else {
			//absolute url is enabled
			var newDomain = 'http://' + domain + window.location.pathname;
			setCurrentClass(mainNavLinkAll, newDomain);
		}
	}

	//hover magic add blue color to icons when hover - remove or change the class if not you like.
	mainNavLinkAll.hover(
	  function () {
	    $(this).find('span.icon16').addClass('blue');
	  }, 
	  function () {
	    $(this).find('span.icon16').removeClass('blue');
	  }
	);

	//click magic
	mainNavLink.click(function(event) {
		var $this = $(this);
		if($this.hasClass('hasUl')) {
			event.preventDefault();
			if($this.hasClass('drop')) {
				$(this).siblings('ul.sub').slideUp(250).siblings().toggleClass('drop');
			} else {
				$(this).siblings('ul.sub').slideDown(250).siblings().toggleClass('drop');
			}			
		} 
	});
	mainNavSubLink.click(function(event) {
		var $this = $(this);
		if($this.hasClass('hasUl')) {
			event.preventDefault();
			if($this.hasClass('drop')) {
				$(this).siblings('ul.sub').slideUp(250).siblings().toggleClass('drop');
			} else {
				$(this).siblings('ul.sub').slideDown(250).siblings().toggleClass('drop');
			}			
		} 
	});

	//responsive buttons
	$('.resBtn>a').click(function(event) {
		var $this = $(this);
		if($this.hasClass('drop')) {
			$this.removeClass('drop');
		} else {
			$this.addClass('drop');
		}
		if($('#sidebar').length) {
			$('#sidebar').toggleClass('offCanvas');
			$('#sidebarbg').toggleClass('offCanvas');
			if($('#sidebar-right').length) {
				$('#sidebar-right').toggleClass('offCanvas');
			}
		}
		if($('#sidebar-right').length) {
			$('#sidebar-right').toggleClass('offCanvas');
			$('#sidebarbg-right').toggleClass('offCanvas');
		}
		$('#content').toggleClass('offCanvas');
		if($('#content-one').length) {
			$('#content-one').toggleClass('offCanvas');
		}
		if($('#content-two').length) {
			$('#content-two').toggleClass('offCanvas');
			$('#sidebar-right').removeClass('offCanvas');
			$('#sidebarbg-right').removeClass('offCanvas');
		}
	});

	$('.resBtnSearch>a').click(function(event) {
		$this = $(this);
		if($this.hasClass('drop')) {
			$('.search').slideUp(250);
		} else {
			$('.search').slideDown(250);
		}
		$this.toggleClass('drop');
	});
	
	//Hide and show sidebar btn

	$(function () {
		//var pages = ['grid.html','charts.html'];
		var pages = [];
	
		for ( var i = 0, j = pages.length; i < j; i++ ) {

		    if($.cookie("currentPage") == pages[i]) {
				var cBtn = $('.collapseBtn.leftbar');
				cBtn.children('a').attr('title','Show Left Sidebar');
				cBtn.addClass('shadow hide');
				cBtn.css({'top': '20px', 'left':'200px'});
				$('#sidebarbg').css('margin-left','-299'+'px');
				$('#sidebar').css('margin-left','-299'+'px');
				if($('#content').length) {
					$('#content').css('margin-left', '0');
				}
				if($('#content-two').length) {
					$('#content-two').css('margin-left', '0');
				}
		    }

		}
		
	});

	$( '.collapseBtn' ).bind( 'click', function(){
	  var $this = $(this);

		//left sidbar clicked
		if ($this.hasClass('leftbar')) {
			
			if($(this).hasClass('hide-sidebar')) {
				//show sidebar
				$this.removeClass('hide-sidebar');
				$this.children('a').attr('title','Hide Left Sidebar');

			} else {
				//hide sidebar
				$this.addClass('hide-sidebar');
				$this.children('a').attr('title','Show Left Sidebar');		
			}
			$('#sidebarbg').toggleClass('hided');
			$('#sidebar').toggleClass('hided')
			$('.collapseBtn.leftbar').toggleClass('top shadow');
			//expand content
			
			if($('#content').length) {
				$('#content').toggleClass('hided');
			}
			if($('#content-two').length) {
				$('#content-two').toggleClass('hided');
			}	

		}

		//right sidebar clicked
		if ($this.hasClass('rightbar')) {
			
			if($(this).hasClass('hide-sidebar')) {
				//show sidebar
				$this.removeClass('hide-sidebar');
				$this.children('a').attr('title','Hide Right Sidebar');
				
			} else {
				//hide sidebar
				$this.addClass('hide-sidebar');
				$this.children('a').attr('title','Show Right Sidebar');
			}
			$('#sidebarbg-right').toggleClass('hided');
			$('#sidebar-right').toggleClass('hided');
			if($('#content').length) {
				$('#content').toggleClass('hided-right');
			}
			if($('#content-one').length) {
				$('#content-one').toggleClass('hided');
			}
			if($('#content-two').length) {
				$('#content-two').toggleClass('hided-right');
			}	
			$('.collapseBtn.rightbar').toggleClass('top shadow')
		}
	});


	//------------- widget panel magic -------------//

	var widget = $('div.panel');
	var widgetOpen = $('div.panel').not('div.panel.closed');
	var widgetClose = $('div.panel.closed');
	//close all widgets with class "closed"
	widgetClose.find('div.panel-body').hide();
	widgetClose.find('.panel-heading>.minimize').removeClass('minimize').addClass('maximize');

	widget.find('.panel-heading>a').click(function (event) {
		event.preventDefault();
		var $this = $(this);
		if($this .hasClass('minimize')) {
			//minimize content
			$this.removeClass('minimize').addClass('maximize');
			$this.parent('div').addClass('min');
			cont = $this.parent('div').next('div.panel-body')
			cont.slideUp(500, 'easeOutExpo'); //change effect if you want :)
			
		} else  
		if($this .hasClass('maximize')) {
			//minimize content
			$this.removeClass('maximize').addClass('minimize');
			$this.parent('div').removeClass('min');
			cont = $this.parent('div').next('div.panel-body');
			cont.slideDown(500, 'easeInExpo'); //change effect if you want :)
		} 
		
	})

	//show minimize and maximize icons
	widget.hover(function() {
		    $(this).find('.panel-heading>a').show(50);	
		}
		, function(){
			$(this).find('.panel-heading>a').hide();	
	});

	//add shadow if hover panel
	widget.not('.drag').hover(function() {
		    $(this).addClass('hover');	
		}
		, function(){
			$(this).removeClass('hover');	
	});

	//------------- Search forms  submit handler  -------------//
	if($('#tipue_search_input').length) {
		$('#tipue_search_input').tipuesearch({
          'show': 5
	     });
		$('#search-form').submit(function() {
		  return false;
		});

		//make custom redirect for search form in .heading
		$('#searchform').submit(function() {
			var sText = $('.top-search').val();
			var sAction = $(this).attr('action');
			var sUrl = sAction + '?q=' + sText;
			$(location).attr('href',sUrl);
			return false;
		});
	}
	//------------- To top plugin  -------------//
	$().UItoTop({ easingType: 'easeOutQuart' });

	//------------- Tooltips -------------//

	//top tooltip
	$('.tip').qtip({
		content: false,
		position: {
			my: 'bottom center',
			at: 'top center',
			viewport: $(window)
		},
		style: {
			classes: 'qtip-tipsy'
		}
	});

	//tooltip in right
	$('.tipR').qtip({
		content: false,
		position: {
			my: 'left center',
			at: 'right center',
			viewport: $(window)
		},
		style: {
			classes: 'qtip-tipsy'
		}
	});

	//tooltip in bottom
	$('.tipB').qtip({
		content: false,
		position: {
			my: 'top center',
			at: 'bottom center',
			viewport: $(window)
		},
		style: {
			classes: 'qtip-tipsy'
		}
	});

	//tooltip in left
	$('.tipL').qtip({
		content: false,
		position: {
			my: 'right center',
			at: 'left center',
			viewport: $(window)
		},
		style: {
			classes: 'qtip-tipsy'
		}
	});

	//------------- Jrespond -------------//
	var jRes = jRespond([
        {
            label: 'small',
            enter: 0,
            exit: 1000
        },{
            label: 'desktop',
            enter: 1001,
            exit: 10000
        }
    ]);

    jRes.addFunc({
        breakpoint: 'small',
        enter: function() {
            $('#sidebarbg,#sidebar,#content').removeClass('hided');
            if($('#content-two').length > 0) {
           		$('.collapseBtn.rightbar').addClass('offCanvas hide-sidebar').find('a').attr('title','Show Right Sidebar');
           		$('#content-two').addClass('hided-right showRb');
           		$('#sidebarbg-right').addClass('hided showRb');
           		$('#sidebar-right').addClass('hided showRb');
            }
        },
        exit: function() {
            $('.collapseBtn.top.hide').removeClass('top hide');
            $('.collapseBtn.rightbar').removeClass('offCanvas');
            $('#content-two').removeClass('hided-right showRb');
            $('#sidebarbg-right').removeClass('hided showRb');
           	$('#sidebar-right').removeClass('hided showRb');
        }
    });
	
	//------------- Uniform  -------------//
	//add class .nostyle if not want uniform to style field
	$("input, textarea, select").not('.nostyle').uniform();

	//remove overlay and show page
	$("#qLoverlay").fadeOut(250);
	$("#qLbar").fadeOut(250);

});