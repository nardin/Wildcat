(function() {

  namespace("Wildcat");

  Wildcat.Core = (function() {
    var layout, log, net;

    Core.name = 'Core';

    function Core() {}

    layout = "test";

    net = "net";

    log = "log";

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
      this.net = new Wildcat.Net();
      Wildcat.Core.load("Wildcat.Block");
      Wildcat.Core.load("Photo.Block.Home");
      Wildcat.Core.load("Photo.Block.Events");
      Wildcat.Core.load("Photo.Block.Event");
      return Wildcat.Core.load("Wildcat.Layout");
    };

    return Core;

  })();

}).call(this);
