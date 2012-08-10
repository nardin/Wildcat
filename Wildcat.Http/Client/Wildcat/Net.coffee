# ”правление передачей данных
class Wildcat.Net
    messageList = []

    constructor:() ->
        @self = @
        console.info("Net : init" )
        window.core.net = @
        console.time("Layout.OnLoad");
        @wsImpl = window.WebSocket || window.MozWebSocket;
        @ws = new @wsImpl('ws://46.61.183.13:8181/Wildcat', 'my-protocol');
        @ws.onopen = @onOpen
        @ws.onmessage = @onMessage
        @ws.onclose = @onClose

    onOpen: (evt) ->
        console.timeEnd("Layout.OnLoad");
        core.net.isConnected = true
        console.log("Connection open ...");
        if typeof(core.net.messageList) != 'undefined'  and core.net.messageList.length > 0
            core.net.ws.send(core.net.messageList[0])

    onClose: (evt) ->
        console.log "Connection close ...";

    onMessage: (evt) ->
        core.onEvent evt.data

    Send : (obj, ev, data) ->
        if @isConnected
            @ws.send(JSON.stringify({object:obj,event:ev,data:data}))
            console.log("push");
        else
            if typeof core.net.messageList == 'undefined'
                core.net.messageList = []
            core.net.messageList.push(JSON.stringify({object:obj,event:ev,data:data}))
            console.log("send");
            



        


        