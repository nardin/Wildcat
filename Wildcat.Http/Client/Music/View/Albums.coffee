namespace "Music.View"
class Music.View.Albums extends Wildcat.View
    render:()->
        console.log(@model)
        @container.html(Music.View.T.Artist.main(@model))