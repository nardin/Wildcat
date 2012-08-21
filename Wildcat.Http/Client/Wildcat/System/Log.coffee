#Логер
class Wildcat.Log

    info:(text, obj)->
        if (typeof obj == 'undefined')
            console.info(text)
        else
            console.groupCollapsed(text)
            console.log obj 
            console.groupEnd()


                
    