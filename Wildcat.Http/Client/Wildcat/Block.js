(function() {
  var __hasProp = {}.hasOwnProperty;

  namespace("Wildcat");

  Wildcat.Block = (function() {

    Block.name = 'Block';

    function Block(id, container) {
      this.id = id;
      this.container = container;
    }

    Block.prototype.init = function() {
      return this._init();
    };

    Block.prototype._init = function() {
      var key, key_id, value, _ref, _results;
      _ref = this._in;
      _results = [];
      for (key in _ref) {
        if (!__hasProp.call(_ref, key)) continue;
        value = _ref[key];
        console.log(key);
        key_id = this.id + '_' + key;
        this.container.append('<div id="' + key_id + '"></div>');
        this._in[key] = new this._in[key](key_id, this.container.find("#" + key_id));
        _results.push(this._in[key].init());
      }
      return _results;
    };

    Block.prototype.load = function() {
      return this._load();
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
      this.container.text("А я блок! А кто ты?");
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
