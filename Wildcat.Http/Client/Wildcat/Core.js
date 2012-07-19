(function() {

  namespace("Wildcat");

  Wildcat.Core = (function() {
    var layout;

    Core.name = 'Core';

    function Core() {}

    layout = "test";

    Core.load = function(classname) {
      var classnamed, self;
      self = this;
      requirejs.config({
        baseUrl: 'Client'
      });
      classnamed = classname.replace(".", "/");
      requirejs([classnamed], function(){self.onLoad(classname)});

      return console.info("load class: " + classname);
    };

    Core.onLoad = function(classname) {
      var obj;
      console.log("event onLoad: " + classname);
      obj = eval("new " + classname + "()");
      if (type(obj.onLoad) === "function") {
        console.log("er");
        return obj.onLoad();
      }
    };

    Core.prototype.init = function() {
      Wildcat.Core.load("Wildcat.Block");
      Wildcat.Core.load("Photo.Block.Home");
      return Wildcat.Core.load("Wildcat.Layout");
    };

    return Core;

  })();

}).call(this);
