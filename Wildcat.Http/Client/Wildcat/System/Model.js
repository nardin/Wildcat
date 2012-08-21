(function() {
  var __hasProp = {}.hasOwnProperty;

  Wildcat.Model = (function() {

    Model.name = 'Model';

    function Model() {}

    Model.prototype.OnLoad = function(json) {
      var i, _results;
      _results = [];
      for (i in json) {
        if (!__hasProp.call(json, i)) continue;
        _results.push(this[i] = json[i]);
      }
      return _results;
    };

    return Model;

  })();

}).call(this);
