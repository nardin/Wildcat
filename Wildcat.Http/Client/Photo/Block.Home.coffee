namespace "Photo"
namespace "Photo.Block"

class Photo.Block.Home extends Wildcat.Block
    
        
    init: ->
        @_in = 
            events: Photo.Block.Events
        @_init()    
        console.log("Home init")

    render: ->
        @_render()
        console.log("Home render")
    



