namespace "Music"
namespace "Music.Block"

class Music.Block.Albums extends Wildcat.Block


    OnLoadData: (data) ->
        @model = data
        @render()

    render: ->
        @container.text("Это Альбомы")