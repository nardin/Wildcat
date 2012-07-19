(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor; child.__super__ = parent.prototype; return child; };

  namespace("Photo");

  namespace("Photo.Block");

  Photo.Block.Home = (function(_super) {

    __extends(Home, _super);

    Home.name = 'Home';

    function Home() {}

    Home.prototype.init = function() {
      this._in = {
        title: Wildcat.Block,
        test: Wildcat.Block
      };
      this._init();
      return console.log("Home init");
    };

    Home.prototype.render = function() {
      this._render();
      return console.log("Home render");
    };

    return Home;

  })(Wildcat.Block);

}).call(this);
