using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace Music.Entity
{
    public class Album : Wildcat.DB.System.Entity
    {

        [ScaffoldColumn(false)]
        public string url;

        [ScaffoldColumn(false)]
        public string title;

        [ScaffoldColumn(false)]
        public string artist;

        [ScaffoldColumn(false)]
        [JsonIgnore]
        public IList<MongoDBRef> sings;

        [ScaffoldColumn(false)]
        public string year;

        [ScaffoldColumn(false)]
        public string pic;
    }
}
