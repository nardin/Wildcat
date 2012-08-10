namespace "Wildcat"

#���������� �������� ������ ������
class Wildcat.Layout
    id : "Layout"

    #������� ������� ����
    mainBlock : undefined

    blocks : {}

    view : undefined

    OnInit: (data) ->
        console.timeEnd("Layout.Router");
        _class = data.class 
        _name = data.name

        @mainBlock = eval('new '+_class+'(_name, this.container)')
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
        @route()

    onEvent: (obj, evn, data)->
        console.log("OnEvent");

    OnRender: (data)->
        if typeof data.name == 'undefined' then data.name = "Layout"
        @view = new Music.View.Layout(undefined,undefined,@)
        @view.render()

    
    # �������������
    route:->    
        @serverEvent("","OnLoad",{url:location.pathname})
        

    serverEvent: (obj, evn, data) ->
        objpath = @id
        if (obj != "")
            objpath += "/" + obj
        core.net.Send(objpath, evn, data)


        





