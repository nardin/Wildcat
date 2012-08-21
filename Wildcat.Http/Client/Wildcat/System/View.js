(function() {
  var __hasProp = {}.hasOwnProperty;

  Wildcat.View = (function() {

    View.name = 'View';

    function View(container, model, block) {
      this.container = container;
      this.model = model;
      this.block = block;
    }

    View.prototype.render = function() {
      return this._render();
    };

    View.prototype._render = function(subBlock) {
      var element, i, _results;
      if (jQuery.isEmptyObject(this.block.block)) {
        return false;
      }
      _results = [];
      for (i in subBlock) {
        if (!__hasProp.call(subBlock, i)) continue;
        element = this.container.find("#" + subBlock[i]);
        _results.push(element.replaceWith(this.block.block[subBlock[i]].container));
      }
      return _results;
    };

    return View;

  })();

}).call(this);
