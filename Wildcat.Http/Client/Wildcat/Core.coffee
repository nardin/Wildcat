namespace "Wildcat"

#���� ���������� �����
class Wildcat.Core
    #����� ���������� �������
    layout = "test"
    net = "net"
    log = "log"

    #�������� �������
    @load: (classname) ->
        self = @
        requirejs.config({baseUrl: 'Client',});
        classnamed = classname.replace(".","/")
        `requirejs([classnamed], function(){self.onLoad(classname)})`
        console.info("load class: "+classname);

    #�������� ������� onLoad � ������������ ������
    @onLoad: (classname) ->
        console.log("event onLoad: " +classname)
        obj = eval("new "+classname+"()")
        if (type(obj.onLoad) == "function")
            console.log("er");
            obj.onLoad()

    init: () ->
        @net = new Wildcat.Net()
        Wildcat.Core.load "Wildcat.Block"
        Wildcat.Core.load "Photo.Block.Home"
        Wildcat.Core.load "Photo.Block.Events"
        Wildcat.Core.load "Photo.Block.Event"
        Wildcat.Core.load "Wildcat.Layout"
