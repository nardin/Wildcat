(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor; child.__super__ = parent.prototype; return child; };

  namespace("Music.View");

  Music.View.Artist = (function(_super) {

    __extends(Artist, _super);

    Artist.name = 'Artist';

    function Artist() {
      return Artist.__super__.constructor.apply(this, arguments);
    }

    Artist.prototype.render = function() {
      console.log(this.model);
      this.container.html(Music.View.T.Artist.main(this.model));
      return this._render(["albums"]);
    };

    return Artist;

  })(Wildcat.View);

}).call(this);
