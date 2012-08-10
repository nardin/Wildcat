namespace "Music.View"
class Music.View.Artist extends Wildcat.View
    render:()->
        console.log(@model)
        @container.html(Music.View.T.Artist.main(@model))
        @_render(["albums"])
