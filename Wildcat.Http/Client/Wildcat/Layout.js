(function() {

  namespace("Wildcat");

  Wildcat.Layout = (function() {

    Layout.name = 'Layout';

    function Layout() {}

    Layout.mainBlock = void 0;

    Layout.prototype.onLoad = function() {
      console.info(this.name + " : onLoad");
      return this.init();
    };

    Layout.prototype.init = function() {
      console.info("Layout : init");
      window.core.layout = this;
      this.container = $("body");
      this.container.html('<div id="layout"></div>');
      this.container = this.container.find("#layout");
      return this.route();
    };

    Layout.prototype.route = function() {
      this.mainBlock = new Photo.Block.Home('main', this.container);
      this.mainBlock.init();
      this.mainBlock.load();
      return this.mainBlock.render();
    };

    return Layout;

  })();

}).call(this);
