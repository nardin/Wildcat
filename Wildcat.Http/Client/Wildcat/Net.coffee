# ”правление передачей данных
class Wildcat.Net
    isConnected = false
    messageList = []

    constructor:() ->
        @s = @
        console.info("Net : init" )
        window.core.net = @
        @wsImpl = window.WebSocket || window.MozWebSocket;
        @ws = new @wsImpl('ws://46.61.183.13:8181/Wildcat', 'my-protocol');
        @ws.onopen = @onOpen
        @ws.onmessage = @onMessage
        @ws.onclose = @onClose

    onOpen: (evt) ->
        console.log("Connection open ...");
        if messageList.length > 0
            @.send(messageList[0])

    onClose: (evt) ->
        console.log "Connection close ...";

    onMessage: (evt) ->
        console.log "Received Message: " + evt.data

    Send : (obj, ev, data) ->
        if @isConnected
            @ws.send(JSON.stringify({object:obj,event:ev,data:data}))
        else
            messageList.push(JSON.stringify({object:obj,event:ev,data:data}))
            



        


        