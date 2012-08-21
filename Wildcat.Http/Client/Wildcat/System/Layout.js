(function() {

  namespace("Wildcat");

  Wildcat.Layout = (function() {

    Layout.name = 'Layout';

    function Layout() {}

    Layout.prototype.id = "Layout";

    Layout.prototype.mainBlock = void 0;

    Layout.prototype.bgBlocks = {};

    Layout.prototype.blocks = {};

    Layout.prototype.view = void 0;

    Layout.prototype.OnAddBgBlock = function(data) {};

    Layout.prototype.OnInit = function(data) {
      var _class, _name;
      console.timeEnd("Layout.Router");
      _class = data["class"];
      _name = data.name;
      this.mainBlock = eval('new ' + _class + '(_name, this.container)');
      this.mainBlock.state = data.state;
      console.log(data.state);
      this.mainBlock.OnInit(data);
      console.info(_name + " : onInit");
      return this.mainBlock.render();
    };

    Layout.prototype.init = function() {
      var self;
      console.info("Layout : init");
      this.container = document.getElementById("layout");
      if (this.container === null) {
        this.container = $("body");
        this.container.html('<div id="layout"></div>');
        this.container = this.container.find("#layout");
      } else {
        this.container = $(this.container);
      }
      console.time("Layout.Router");
      self = this;
      window.addEventListener("popstate", function() {
        return self.route();
      });
      return this.route();
    };

    Layout.prototype.onEvent = function(obj, evn, data) {
      return console.log("OnEvent");
    };

    Layout.prototype.OnRender = function(data) {
      if (typeof data.name === 'undefined') {
        data.name = "Layout";
      }
      this.view = new Music.View.Layout(void 0, void 0, this);
      return this.view.render();
    };

    Layout.prototype.route = function() {
      this.mainBlock = void 0;
      this.blocks = {};
      this.container.html("");
      return this.serverEvent("", "OnLoad", {
        url: location.pathname
      });
    };

    Layout.prototype.serverEvent = function(obj, evn, data) {
      var objpath;
      objpath = this.id;
      if (obj !== "") {
        objpath += "/" + obj;
      }
      return core.net.Send(objpath, evn, data);
    };

    return Layout;

  })();

}).call(this);
