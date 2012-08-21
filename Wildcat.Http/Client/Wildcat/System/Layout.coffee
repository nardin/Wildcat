namespace "Wildcat"

#Управление жизненым циклом блоков
class Wildcat.Layout
    id : "Layout"

    #Текущий главный блок
    mainBlock : undefined

    bgBlocks: {}

    blocks : {}

    view : undefined


    OnAddBgBlock: (data)->
        

    OnInit: (data) ->
        console.timeEnd("Layout.Router");
        _class = data.class 
        _name = data.name

        @mainBlock = eval('new '+_class+'(_name, this.container)')
        @mainBlock.state = data.state
        console.log(data.state)
        @mainBlock.OnInit(data)
        console.info(_name + " : onInit" )
        @mainBlock.render()

    init: ->
        console.info("Layout : init" )
        @container = document.getElementById("layout")
        if @container == null
            @container = $("body")
            @container.html('<div id="layout"></div>')
            @container = @container.find("#layout")
        else
            @container = $(@container)
        console.time("Layout.Router");
        self = @
        window.addEventListener("popstate", -> self.route());
        @route()

    onEvent: (obj, evn, data)->
        console.log("OnEvent");

    OnRender: (data)->
        if typeof data.name == 'undefined' then data.name = "Layout"
        @view = new Music.View.Layout(undefined,undefined,@)
        @view.render()

    
    # Маршрутизация
    route:->
        @mainBlock = undefined
        @blocks = {}
        @container.html("");
        @serverEvent("","OnLoad",{url:location.pathname})
        

    serverEvent: (obj, evn, data) ->
        objpath = @id
        if (obj != "")
            objpath += "/" + obj
        core.net.Send(objpath, evn, data)


        





