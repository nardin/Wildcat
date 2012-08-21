class Music.Block.Artists extends Wildcat.BlockList

                
    render: ->
        @view = new Wildcat.View(@container, @model,@)
        @_render()