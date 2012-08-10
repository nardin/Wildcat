(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor; child.__super__ = parent.prototype; return child; };

  namespace("Music");

  namespace("Music.Block");

  Music.Block.Albums = (function(_super) {

    __extends(Albums, _super);

    Albums.name = 'Albums';

    function Albums() {
      return Albums.__super__.constructor.apply(this, arguments);
    }

    Albums.prototype.OnLoadData = function(data) {
      this.model = data;
      return this.render();
    };

    Albums.prototype.render = function() {
      return this.container.text("Это Альбомы");
    };

    return Albums;

  })(Wildcat.Block);

}).call(this);
