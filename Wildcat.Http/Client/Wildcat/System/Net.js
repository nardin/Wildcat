(function() {

  Wildcat.Net = (function() {
    var messageList;

    Net.name = 'Net';

    messageList = [];

    function Net() {
      this.self = this;
      console.info("Net : init");
      window.core.net = this;
      console.time("Layout.OnLoad");
      this.wsImpl = window.WebSocket || window.MozWebSocket;
      this.ws = new this.wsImpl('ws://46.61.183.13:8181/Wildcat', 'my-protocol');
      this.ws.onopen = this.onOpen;
      this.ws.onmessage = this.onMessage;
      this.ws.onclose = this.onClose;
    }

    Net.prototype.onOpen = function(evt) {
      console.timeEnd("Layout.OnLoad");
      core.net.isConnected = true;
      console.log("Connection open ...");
      if (typeof core.net.messageList !== 'undefined' && core.net.messageList.length > 0) {
        return core.net.ws.send(core.net.messageList[0]);
      }
    };

    Net.prototype.onClose = function(evt) {
      return console.log("Connection close ...");
    };

    Net.prototype.onMessage = function(evt) {
      return core.onEvent(evt.data);
    };

    Net.prototype.Send = function(obj, ev, data) {
      if (this.isConnected) {
        this.ws.send(JSON.stringify({
          object: obj,
          event: ev,
          data: data
        }));
        return console.log("push");
      } else {
        if (typeof core.net.messageList === 'undefined') {
          core.net.messageList = [];
        }
        core.net.messageList.push(JSON.stringify({
          object: obj,
          event: ev,
          data: data
        }));
        return console.log("send");
      }
    };

    return Net;

  })();

}).call(this);
