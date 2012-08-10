(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor; child.__super__ = parent.prototype; return child; };

  namespace("Music.View");

  Music.View.Layout = (function(_super) {

    __extends(Layout, _super);

    Layout.name = 'Layout';

    function Layout() {
      return Layout.__super__.constructor.apply(this, arguments);
    }

    Layout.prototype.render = function() {
      console.log("layout Render");
      document.getElementsByTagName("body")[0].innerHTML = Music.View.T.Layout.main();
      return $("#layout").replaceWith(this.block.container);
    };

    return Layout;

  })(Wildcat.View);

}).call(this);
