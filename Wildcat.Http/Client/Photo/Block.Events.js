(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor; child.__super__ = parent.prototype; return child; };

  namespace("Photo");

  namespace("Photo.Block");

  Photo.Block.Events = (function(_super) {

    __extends(Events, _super);

    Events.name = 'Events';

    function Events() {
      return Events.__super__.constructor.apply(this, arguments);
    }

    Events.prototype.init = function() {
      this._in = {};
      this._init();
      return console.log("Home init");
    };

    Events.prototype.load = function() {
      var i, key_id, _i, _results;
      this._in[i] = {};
      _results = [];
      for (i = _i = 0; _i <= 1000; i = ++_i) {
        key_id = this.id + '_' + i;
        this.container.append('<div id="' + key_id + '"></div>');
        this._in[i] = new Photo.Block.Event(key_id, this.container.find("#" + key_id));
        this._in[i].init();
        _results.push(this._in[i].load());
      }
      return _results;
    };

    Events.prototype.render = function() {
      this._render();
      return console.log("Home render");
    };

    return Events;

  })(Wildcat.Block);

}).call(this);
