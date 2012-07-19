namespace "Wildcat"

#Управление жизненым циклом блоков
class Wildcat.Layout
    #Текущий главный блок
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

    # Маршрутизация
    route:->
        @mainBlock = new Photo.Block.Home()
        @mainBlock.init()
        @mainBlock.load()
        @mainBlock.render()
        





