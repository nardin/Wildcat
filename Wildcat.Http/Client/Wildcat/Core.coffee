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
        requirejs.config({baseUrl: 'Client',});
        classnamed = classname.replace(".","/")
        `requirejs([classnamed], function(){self.onLoad(classname)})`
        console.info("load class: "+classname);

    #Вызываем событие onLoad у загруженного модуля
    @onLoad: (classname) ->
        console.log("event onLoad: " +classname)
        obj = eval("new "+classname+"()")
        if (type(obj.onLoad) == "function")
            console.log("er");
            obj.onLoad()


    init: () ->
        @net = new Wildcat.Net()
        @layout = new Wildcat.Layout();
        @layout.init();


        
