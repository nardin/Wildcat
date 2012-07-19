namespace "Wildcat"

# Базовый класс всех блоков
class Wildcat.Block

    constructor: ->        

    init:->
        @_init()
        console.log("blokc init")
    _init: ->
        for own key, value of @_in
            console.log key
            @_in[key] = new @_in[key]()
            @_in[key].init()

    load:->
        @_load()
        console.log("blokc load")
        
    _load: ->
        for own key, value of @_in
            @_in[key].load()

    render:->
        console.log("block render")
        @_render()
        
    _render: ->
        for own key, value of @_in
            @_in[key].render()
        