namespace "Wildcat"

#���������� �������� ������ ������
class Wildcat.Layout
    #������� ������� ����
    @mainBlock = undefined

    onLoad: ->
        console.info(@name + " : onLoad" )
        @init()


    init: ->
        console.info("Layout : init" )
        window.core.layout = @
        @container = $("body")
        @container.html('<div id="layout"></div>')
        @route()

    # �������������
    route:->
        @mainBlock = new Photo.Block.Home()
        @mainBlock.init()
        @mainBlock.load()
        @mainBlock.render()
        





