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
        @container = @container.find("#layout")
        @route()

    # �������������
    route:->
        @mainBlock = new Photo.Block.Home('main',@container)
        @mainBlock.init()
        @mainBlock.load()
        @mainBlock.render()
        





