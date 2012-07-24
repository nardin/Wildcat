namespace "Wildcat"

# Базовый класс всех блоков
class Wildcat.Block

    constructor:(@id,@container) ->        

    init:->
        @_init()
        #console.log("blokc init")
    _init: ->
        for own key, value of @_in
            console.log key

            key_id = @id+'_'+key
            @container.append('<div id="'+key_id+'"></div>')

            @_in[key] = new @_in[key](key_id, @container.find("#"+key_id))
            @_in[key].init()

    load:->
        @_load()
        #console.log("blokc load")
        
    _load: ->
        for own key, value of @_in
            @_in[key].load()

    render:->
        #console.log("block render")
        @container.text("А я блок! А кто ты?")
        @_render()
        
    _render: ->
        for own key, value of @_in
            @_in[key].render()
        