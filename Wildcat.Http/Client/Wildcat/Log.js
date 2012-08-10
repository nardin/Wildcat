(function() {

  Wildcat.Log = (function() {

    Log.name = 'Log';

    function Log() {}

    Log.prototype.info = function(text, obj) {
      if (typeof obj === 'undefined') {
        return console.info(text);
      } else {
        console.groupCollapsed(text);
        console.log(obj);
        return console.groupEnd();
      }
    };

    return Log;

  })();

}).call(this);
