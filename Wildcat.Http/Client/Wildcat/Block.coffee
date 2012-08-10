namespace "Wildcat"

# Базовый класс всех блоков
class Wildcat.Block

    constructor:(@id,@container,@parent) ->
        if (typeof @parent != 'undefined')
            @fullId = @parent.fullId + "/" + id;        
        else
            @fullId = id;
        core.layout.blocks[@fullId] = @

    OnInit: (data)->

        @_onInit(data)
        #console.log("blokc init")
    _onInit:(data) ->
        @block = {}
        child = data.child
        @container.html('<div id="'+data.name+'"></div>')
        @container = @container.find("#"+data.name)
        if child.length > 0
            for i in [0.. child.length-1]
                _class = child[i].class 
                _name = child[i].name        
                @block[_name] = eval('new '+_class+'(_name, this.container, this)')
                @block[_name].id = _name;
                @block[_name].OnInit(child[i])
                true 
        @load()

    load:->
        core.net.Send(@fullId,"OnLoadData",{});

    render:->
        #console.log("block render")
        @container.text("А я блок! А кто ты?")
        @_render()
        
    _render: ->
        @view.render();
        