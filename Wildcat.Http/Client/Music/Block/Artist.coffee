namespace "Music"
namespace "Music.Block"

class Music.Block.Artist extends Wildcat.Block
    init: ->
        @_in = {}
        @_init()    
        #console.log("Home init")

    render: ->
        @container.text("��� ������")
        @_render()
        console.log("Home block artist")