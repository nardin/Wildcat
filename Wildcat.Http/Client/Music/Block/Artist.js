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

    Artist.prototype.OnLoadData = function(data) {
      this.model = new Music.Model.Artist();
      this.model.OnLoad(data);
      return this.render();
    };

    Artist.prototype.render = function() {
      this.view = new Music.View.Artist(this.container, this.model, this);
      return this._render();
    };

    return Artist;

  })(Wildcat.Block);

}).call(this);
