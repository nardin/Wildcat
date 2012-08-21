(function() {

  namespace("Wildcat");

  Wildcat.Block = (function() {

    Block.name = 'Block';

    function Block(id, container, parent) {
      this.id = id;
      this.container = container;
      this.parent = parent;
      if (typeof this.parent !== 'undefined') {
        this.fullId = this.parent.fullId + "/" + id;
      } else {
        this.fullId = id;
      }
      core.layout.blocks[this.fullId] = this;
    }

    Block.prototype.OnInit = function(data) {
      return this._onInit(data);
    };

    Block.prototype._onInit = function(data) {
      var child, i, _class, _i, _name, _ref;
      this.block = {};
      child = data.child;
      this.container.append('<div id="' + data.name + '"></div>');
      this.container = this.container.find("#" + data.name);
      if (child.length > 0) {
        for (i = _i = 0, _ref = child.length - 1; 0 <= _ref ? _i <= _ref : _i >= _ref; i = 0 <= _ref ? ++_i : --_i) {
          _class = child[i]["class"];
          _name = child[i].name;
          this.block[_name] = eval('new ' + _class + '(_name, this.container, this)');
          this.block[_name].id = _name;
          this.block[_name].state = child[i].state;
          this.block[_name].OnInit(child[i]);
          true;

        }
      }
      return this.load();
    };

    Block.prototype.load = function() {
      return core.net.Send(this.fullId, "OnLoadData", {});
    };

    Block.prototype.render = function() {
      this.container.text("А я блок! А кто ты?");
      return this._render();
    };

    Block.prototype._render = function() {
      return this.view.render();
    };

    Block.prototype.IMain = function() {};

    return Block;

  })();

}).call(this);
