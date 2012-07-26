(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor; child.__super__ = parent.prototype; return child; };

  namespace("Music");

  namespace("Music.Block");

  Music.Block.Artist = (function(_super) {

    __extends(Artist, _super);

    Artist.name = 'Artist';

    function Artist() {
      return Artist.__super__.constructor.apply(this, arguments);
    }

    Artist.prototype.init = function() {
      this._in = {};
      return this._init();
    };

    Artist.prototype.render = function() {
      this.container.text("Это артист");
      this._render();
      return console.log("Home block artist");
    };

    return Artist;

  })(Wildcat.Block);

}).call(this);
