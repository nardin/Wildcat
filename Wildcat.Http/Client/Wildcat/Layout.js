(function() {

  namespace("Wildcat");

  Wildcat.Layout = (function() {
    var id;

    Layout.name = 'Layout';

    function Layout() {}

    id = "Layout";

    Layout.mainBlock = void 0;

    Layout.prototype.onLoad = function() {
      console.info(this.name + " : onLoad");
      return this.init();
    };

    Layout.prototype.init = function() {
      console.info("Layout : init");
      this.container = $("body");
      this.container.html('<div id="layout"></div>');
      this.container = this.container.find("#layout");
      return this.route();
    };

    Layout.prototype.onEvent = function(obj, evn, data) {
      return console.log("OnEvent");
    };

    Layout.prototype.route = function() {
      return this.serverEvent("", "OnLoad", location.pathname);
    };

    Layout.prototype.serverEvent = function(obj, evn, data) {
      var objpath;
      objpath = id;
      if (obj !== "") {
        objpath += "/" + obj;
      }
      return core.net.Send(objpath, evn, data);
    };

    return Layout;

  })();

}).call(this);
