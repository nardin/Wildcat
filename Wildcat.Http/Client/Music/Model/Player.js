(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor; child.__super__ = parent.prototype; return child; };

  namespace("Music");

  namespace("Music.Model");

  Music.Model.Player = (function(_super) {

    __extends(Player, _super);

    Player.name = 'Player';

    function Player() {
      return Player.__super__.constructor.apply(this, arguments);
    }

    return Player;

  })(Wildcat.Model);

}).call(this);
