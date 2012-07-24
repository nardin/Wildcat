namespace "Photo"
namespace "Photo.Block"

class Photo.Block.Events extends Wildcat.Block
        
    init: ->
        @_in = {}

        @_init()    
        console.log("Home init")
    load: ->
        @_in[i] = {}
        for i in [0..1000]
            key_id = @id+'_'+i
            @container.append('<div id="'+key_id+'"></div>')

            @_in[i] = new Photo.Block.Event(key_id, @container.find("#"+key_id))
            @_in[i].init()   
            @_in[i].load()


    render: ->
        @_render()
        console.log("Home render")