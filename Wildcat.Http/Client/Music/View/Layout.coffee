namespace "Music.View"
class Music.View.Layout extends Wildcat.View
    render:()->
        console.log("layout Render");
        document.getElementsByTagName("body")[0].innerHTML = Music.View.T.Layout.main()
        $("#layout").replaceWith(@block.container)