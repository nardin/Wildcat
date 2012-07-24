// This file was automatically generated from View.Event.soy.
// Please don't edit this file by hand.

if (typeof Photo == 'undefined') { var Photo = {}; }
if (typeof Photo.View == 'undefined') { Photo.View = {}; }


Photo.View.event = function(opt_data, opt_sb) {
  var output = opt_sb || new soy.StringBuilder();
  output.append('Событие : ', soy.$$escapeHtml(opt_data.name));
  return opt_sb ? '' : output.toString();
};
