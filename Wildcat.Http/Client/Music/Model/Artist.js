(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor; child.__super__ = parent.prototype; return child; };

  namespace("Music");

  namespace("Music.Model");

  Music.Model.Artist = (function(_super) {

    __extends(Artist, _super);

    Artist.name = 'Artist';

    function Artist() {
      return Artist.__super__.constructor.apply(this, arguments);
    }

    return Artist;

  })(Wildcat.Model);

}).call(this);
