class Wildcat.BlockList extends Wildcat.Block
    block : {}

    OnAddBlocks:(data)->
        child = data.child
        if child.length > 0
            for i in [0.. child.length-1]
                _class = child[i].class 
                _name = child[i].name        
                @block[_name] = eval('new '+_class+'(_name, this.container, this)')
                @block[_name].id = _name;
                @block[_name].state = child[i].state;
                @block[_name].OnInit(child[i])
                true 