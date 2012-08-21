(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor; child.__super__ = parent.prototype; return child; };

  Wildcat.BlockList = (function(_super) {

    __extends(BlockList, _super);

    BlockList.name = 'BlockList';

    function BlockList() {
      return BlockList.__super__.constructor.apply(this, arguments);
    }

    BlockList.prototype.block = {};

    BlockList.prototype.OnAddBlocks = function(data) {
      var child, i, _class, _i, _name, _ref, _results;
      child = data.child;
      if (child.length > 0) {
        _results = [];
        for (i = _i = 0, _ref = child.length - 1; 0 <= _ref ? _i <= _ref : _i >= _ref; i = 0 <= _ref ? ++_i : --_i) {
          _class = child[i]["class"];
          _name = child[i].name;
          this.block[_name] = eval('new ' + _class + '(_name, this.container, this)');
          this.block[_name].id = _name;
          this.block[_name].state = child[i].state;
          this.block[_name].OnInit(child[i]);
          _results.push(true);
        }
        return _results;
      }
    };

    return BlockList;

  })(Wildcat.Block);

}).call(this);
