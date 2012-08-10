(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor; child.__super__ = parent.prototype; return child; };

  Music.Block.Artists = (function(_super) {

    __extends(Artists, _super);

    Artists.name = 'Artists';

    function Artists() {
      return Artists.__super__.constructor.apply(this, arguments);
    }

    Artists.prototype.render = function() {
      this.view = new Music.View.Artist(this.container, this.model, this);
      return this._render();
    };

    return Artists;

  })(Wildcat.Block);

}).call(this);
