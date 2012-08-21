// This file was automatically generated from Artist.soy.
// Please don't edit this file by hand.

if (typeof Music == 'undefined') { var Music = {}; }
if (typeof Music.View == 'undefined') { Music.View = {}; }
if (typeof Music.View.T == 'undefined') { Music.View.T = {}; }
if (typeof Music.View.T.Artist == 'undefined') { Music.View.T.Artist = {}; }


Music.View.T.Artist.main = function(opt_data, opt_sb) {
  var output = opt_sb || new soy.StringBuilder();
  output.append('<div>Исполнитель: ', soy.$$escapeHtml(opt_data.name), ' </div><div>Постер: ', soy.$$escapeHtml(opt_data.poster), ' </div><div id="albums"></div>');
  return opt_sb ? '' : output.toString();
};


Music.View.T.Artist.small = function(opt_data, opt_sb) {
  var output = opt_sb || new soy.StringBuilder();
  output.append('<a><div class="artist-crop" style="background: #FFFFFF url(/Content/artist/160x160/);"></div><div class="artist-info"><div class="artist-name">', soy.$$escapeHtml(opt_data.name), '</div><div class="artist-count">1 / 3</div></div></a>');
  return opt_sb ? '' : output.toString();
};
