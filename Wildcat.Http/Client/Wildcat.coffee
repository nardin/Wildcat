# Пространство имен
@namespace = (target, name, block) ->
  [target, name, block] = [(if typeof exports isnt 'undefined' then exports else window), arguments...] if arguments.length < 3
  top    = target
  target = target[item] or= {} for item in name.split '.'
  console.log(target)
  #block target, top

#Сомнительное использование
@newc = (classname) ->
    if (eval('typeof ' + classname) != 'function') 
        Wildcat.Core.load  "classname"
    else
        return new classname()

@type = (obj) ->
  if obj == undefined or obj == null
    return String obj
  classToType = new Object
  for name in "Boolean Number String Function Array Date RegExp".split(" ")
    classToType["[object " + name + "]"] = name.toLowerCase()
  myClass = Object.prototype.toString.call obj
  if myClass of classToType
    return classToType[myClass]
  return "object"

window.onload = ->
    window.core = new Wildcat.Core()
    window.core.init()
     

    





    