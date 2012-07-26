(function() {

  Wildcat.Net = (function() {
    var isConnected, messageList;

    Net.name = 'Net';

    isConnected = false;

    messageList = [];

    function Net() {
      this.s = this;
      console.info("Net : init");
      window.core.net = this;
      this.wsImpl = window.WebSocket || window.MozWebSocket;
      this.ws = new this.wsImpl('ws://46.61.183.13:8181/Wildcat', 'my-protocol');
      this.ws.onopen = this.onOpen;
      this.ws.onmessage = this.onMessage;
      this.ws.onclose = this.onClose;
    }

    Net.prototype.onOpen = function(evt) {
      console.log("Connection open ...");
      if (messageList.length > 0) {
        return this.send(messageList[0]);
      }
    };

    Net.prototype.onClose = function(evt) {
      return console.log("Connection close ...");
    };

    Net.prototype.onMessage = function(evt) {
      return console.log("Received Message: " + evt.data);
    };

    Net.prototype.Send = function(obj, ev, data) {
      if (this.isConnected) {
        return this.ws.send(JSON.stringify({
          object: obj,
          event: ev,
          data: data
        }));
      } else {
        return messageList.push(JSON.stringify({
          object: obj,
          event: ev,
          data: data
        }));
      }
    };

    return Net;

  })();

}).call(this);
