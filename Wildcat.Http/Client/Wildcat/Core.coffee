namespace "Wildcat"

#Ядро клиентской части
class Wildcat.Core
    #Макет управления блоками
    layout = "test"
    net = "net"
    log = "log"

    #Загрузка модулей
    @load: (classname) ->
        self = @
        

    #Вызываем событие onLoad у загруженного модуля
    @onLoad: (classname) ->
        console.log("event onLoad: " +classname)
        obj = eval("new "+classname+"()")
        if (type(obj.onLoad) == "function")
            console.log("er");
            obj.onLoad()


    init: () ->
        console.time("Core.init");
        @log = new Wildcat.Log()
        @net = new Wildcat.Net()
        @layout = new Wildcat.Layout();
        @layout.init();
        console.timeEnd("Core.init");

    onEvent: (evt) ->
        data = JSON.parse(evt) 
        console.groupCollapsed("Событие: "+data.event + " для " + data.object)
        console.log data.data 
        console.groupEnd()
        if (data.object == "Layout")
            @layout[data.event](data.data)
        else
            @layout.blocks[data.object][data.event](data.data)
        




        
