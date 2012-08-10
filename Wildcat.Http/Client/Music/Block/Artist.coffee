namespace "Music"
namespace "Music.Block"

class Music.Block.Artist extends Wildcat.Block
    OnLoadData: (data) ->
        @model = new Music.Model.Artist();
        @model.OnLoad(data);
        @render()

    render: ->
        @view = new Music.View.Artist(@container, @model,@)
        @_render()
        