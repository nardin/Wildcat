(function() {

  Wildcat.Net = (function() {

    Net.name = 'Net';

    function Net() {
      console.info("Net : init");
      window.core.net = this;
      this.wsImpl = window.WebSocket || window.MozWebSocket;
      this.ws = new this.wsImpl('ws://46.0.183.30:8181/Wildcat', 'my-protocol');
      this.ws.onopen = this.onOpen;
      this.ws.onmessage = this.onMessage;
      this.ws.onclose = this.onClose;
    }

    Net.prototype.onOpen = function(evt) {
      return console.log("Connection open ...");
    };

    Net.prototype.onClose = function(evt) {
      return console.log("Connection close ...");
    };

    Net.prototype.onMessage = function(evt) {
      return console.log("Received Message: " + evt.data);
    };

    Net.prototype.Send = function(obj, ev, data) {
      return this.ws.send(JSON.stringify({
        object: obj,
        event: ev,
        data: data
      }));
    };

    return Net;

  })();

}).call(this);
