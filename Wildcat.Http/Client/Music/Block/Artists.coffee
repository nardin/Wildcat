class Music.Block.Artists extends Wildcat.Block

                
    render: ->
        @view = new Music.View.Artist(@container, @model,@)
        @_render()