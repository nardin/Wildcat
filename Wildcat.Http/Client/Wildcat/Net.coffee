# ”правление передачей данных
class Wildcat.Net
    constructor:() ->
        console.info("Net : init" )
        window.core.net = @
        @wsImpl = window.WebSocket || window.MozWebSocket;
        @ws = new @wsImpl('ws://46.0.183.30:8181/Wildcat', 'my-protocol');
        @ws.onopen = @onOpen
        @ws.onmessage = @onMessage
        @ws.onclose = @onClose

    onOpen: (evt) ->
        console.log("Connection open ...");

    onClose: (evt) ->
        console.log "Connection close ...";

    onMessage: (evt) ->
        console.log "Received Message: " + evt.data;

    Send : (obj, ev, data) ->
        @ws.send(JSON.stringify({object:obj,event:ev,data:data}))



        


        