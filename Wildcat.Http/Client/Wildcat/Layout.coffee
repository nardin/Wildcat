namespace "Wildcat"

#Управление жизненым циклом блоков
class Wildcat.Layout
    id = "Layout"

    #Текущий главный блок
    @mainBlock = undefined

    onLoad: ->
        console.info(@name + " : onLoad" )
        @init()


    init: ->
        console.info("Layout : init" )

        @container = $("body")
        @container.html('<div id="layout"></div>')
        @container = @container.find("#layout")
        @route()
    onEvent: (obj, evn, data)->
        console.log("OnEvent");
    

    # Маршрутизация
    route:->
        @serverEvent("","OnLoad",location.pathname)
        
        #@mainBlock = new Music.Block.Artist('main',@container)

        #@mainBlock.init()
        #@mainBlock.load()
        #@mainBlock.render()

    serverEvent: (obj, evn, data) ->
        objpath = id
        if (obj != "")
            objpath += "/" + obj
        core.net.Send(objpath, evn, data)


        





