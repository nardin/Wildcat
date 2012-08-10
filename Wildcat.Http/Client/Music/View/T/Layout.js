// This file was automatically generated from Layout.soy.
// Please don't edit this file by hand.

if (typeof Music == 'undefined') { var Music = {}; }
if (typeof Music.View == 'undefined') { Music.View = {}; }
if (typeof Music.View.T == 'undefined') { Music.View.T = {}; }
if (typeof Music.View.T.Layout == 'undefined') { Music.View.T.Layout = {}; }


Music.View.T.Layout.main = function(opt_data, opt_sb) {
  var output = opt_sb || new soy.StringBuilder();
  output.append('<div class="navbar navbar-fixed-top"><div class="navbar-inner"><div class="container"><a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse"><span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></a><div class="nav-collapse"><ul class="nav"><li><a href="/"><i class="icon-home icon-white"></i></a></li><!--<li><a href="/">Избранное</a></li>--><li><a href="/Now">Сейчас слушают</a></li><li><a href="/About">О проекте</a></li></ul><p class="navbar-text pull-right"><a href="">46.61.183.13</a></p></div></div></div></div><div id="layout" class="container"></div>');
  return opt_sb ? '' : output.toString();
};
