(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor; child.__super__ = parent.prototype; return child; };

  namespace("Music");

  namespace("Music.Block");

  Music.Block.Playe = (function(_super) {

    __extends(Playe, _super);

    Playe.name = 'Playe';

    function Playe() {
      return Playe.__super__.constructor.apply(this, arguments);
    }

    Playe.prototype.OnLoadData = function(data) {
      this.model = new Music.Model.Artist();
      this.model.OnLoad(data);
      return this.render();
    };

    Playe.prototype.render = function() {
      this.view = new Music.View.Player(this.container, this.model, this);
      return this._render();
    };

    return Playe;

  })(Wildcat.Block);

}).call(this);
