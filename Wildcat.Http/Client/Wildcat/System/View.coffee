class Wildcat.View
    constructor:(@container,@model, @block)->

    render:()->
        @_render();

    _render:(subBlock)->
        if jQuery.isEmptyObject(@block.block) then return false

        for own i of subBlock
            element = @container.find("#"+subBlock[i])
            element.replaceWith(@block.block[subBlock[i]].container)

        

        