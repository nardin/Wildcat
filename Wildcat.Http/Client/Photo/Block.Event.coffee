namespace "Photo"
namespace "Photo.Block"

class Photo.Block.Event extends Wildcat.Block
    
        
    init: ->
        @_in = {}
        @_init()    
        #console.log("Home init")

    render: ->
        @container.text("Это важное событие")
        @_render()
        #console.log("Home render")