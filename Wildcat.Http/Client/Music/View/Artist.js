(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor; child.__super__ = parent.prototype; return child; };

  namespace("Music.View");

  Music.View.Artist = (function(_super) {

    __extends(Artist, _super);

    Artist.name = 'Artist';

    function Artist() {
      return Artist.__super__.constructor.apply(this, arguments);
    }

    Artist.prototype.render = function() {
      var self;
      console.info(this.block.state);
      if (this.block.state === "Small") {
        this.container.addClass("artist-block");
        this.container.html(Music.View.T.Artist.small(this.model));
        self = this;
        this.container.click(function() {
          return self.OnClick();
        });
      } else {
        this.container.html(Music.View.T.Artist.main(this.model));
      }
      return this._render(["albums"]);
    };

    Artist.prototype.OnClick = function() {
      history.pushState(null, null, "/Music/Artist/" + this.model.url + "/");
      core.layout.route();
      return false;
    };

    return Artist;

  })(Wildcat.View);

}).call(this);
