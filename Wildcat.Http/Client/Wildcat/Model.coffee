class Wildcat.Model
    OnLoad: (json) ->
        for own i of json
            @[i] = json[i];
            