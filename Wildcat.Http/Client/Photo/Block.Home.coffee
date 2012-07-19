namespace "Photo"
namespace "Photo.Block"

class Photo.Block.Home extends Wildcat.Block
    
    constructor: ->
        
    init: ->
        @_in = 
            title: Wildcat.Block
            test: Wildcat.Block
        @_init()    
        console.log("Home init")

    render: ->
        @_render()
        console.log("Home render")
    



