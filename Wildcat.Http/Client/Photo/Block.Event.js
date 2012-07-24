(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor; child.__super__ = parent.prototype; return child; };

  namespace("Photo");

  namespace("Photo.Block");

  Photo.Block.Event = (function(_super) {

    __extends(Event, _super);

    Event.name = 'Event';

    function Event() {
      return Event.__super__.constructor.apply(this, arguments);
    }

    Event.prototype.init = function() {
      this._in = {};
      return this._init();
    };

    Event.prototype.render = function() {
      this.container.text("Это важное событие");
      return this._render();
    };

    return Event;

  })(Wildcat.Block);

}).call(this);
