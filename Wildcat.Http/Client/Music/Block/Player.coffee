namespace "Music"
namespace "Music.Block"

class Music.Block.Playe extends Wildcat.Block
    OnLoadData: (data) ->
        @model = new Music.Model.Artist();
        @model.OnLoad(data);
        @render()

    render: ->
        @view = new Music.View.Player(@container, @model,@)
        @_render()