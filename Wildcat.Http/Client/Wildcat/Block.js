(function() {
  var __hasProp = {}.hasOwnProperty;

  namespace("Wildcat");

  Wildcat.Block = (function() {

    Block.name = 'Block';

    function Block() {}

    Block.prototype.init = function() {
      this._init();
      return console.log("blokc init");
    };

    Block.prototype._init = function() {
      var key, value, _ref, _results;
      _ref = this._in;
      _results = [];
      for (key in _ref) {
        if (!__hasProp.call(_ref, key)) continue;
        value = _ref[key];
        console.log(key);
        this._in[key] = new this._in[key]();
        _results.push(this._in[key].init());
      }
      return _results;
    };

    Block.prototype.load = function() {
      this._load();
      return console.log("blokc load");
    };

    Block.prototype._load = function() {
      var key, value, _ref, _results;
      _ref = this._in;
      _results = [];
      for (key in _ref) {
        if (!__hasProp.call(_ref, key)) continue;
        value = _ref[key];
        _results.push(this._in[key].load());
      }
      return _results;
    };

    Block.prototype.render = function() {
      console.log("block render");
      return this._render();
    };

    Block.prototype._render = function() {
      var key, value, _ref, _results;
      _ref = this._in;
      _results = [];
      for (key in _ref) {
        if (!__hasProp.call(_ref, key)) continue;
        value = _ref[key];
        _results.push(this._in[key].render());
      }
      return _results;
    };

    return Block;

  })();

}).call(this);
