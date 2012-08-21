namespace "Music.View"
class Music.View.Artist extends Wildcat.View
    render:()->
        
        console.info(@block.state)
        if (@block.state == "Small")
            @container.addClass("artist-block")
            @container.html(Music.View.T.Artist.small(@model))
            self = @
            @container.click -> 
                self.OnClick()
        else
            @container.html(Music.View.T.Artist.main(@model))
        @_render(["albums"])

    OnClick:()->
        history.pushState(null, null, "/Music/Artist/"+@model.url+"/");
        core.layout.route()
        false
