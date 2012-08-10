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
      var self;
      return self = this;
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
      console.time("Core.init");
      this.log = new Wildcat.Log();
      this.net = new Wildcat.Net();
      this.layout = new Wildcat.Layout();
      this.layout.init();
      return console.timeEnd("Core.init");
    };

    Core.prototype.onEvent = function(evt) {
      var data;
      data = JSON.parse(evt);
      console.groupCollapsed("Событие: " + data.event + " для " + data.object);
      console.log(data.data);
      console.groupEnd();
      if (data.object === "Layout") {
        return this.layout[data.event](data.data);
      } else {
        return this.layout.blocks[data.object][data.event](data.data);
      }
    };

    return Core;

  })();

}).call(this);
