using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace Music.Entity
{
    public class Artist : Wildcat.DB.System.Entity
    {
        [ScaffoldColumn(false)]
        public string url;

        [ScaffoldColumn(false)]
        public string name;

        [ScaffoldColumn(false)]
        public string poster;

        [ScaffoldColumn(false)]
        public string bigPoster;

        [ScaffoldColumn(false)]
        [JsonIgnore]
        public IList<MongoDBRef> sings;

        [ScaffoldColumn(false)]
        [JsonIgnore]
        public IList<MongoDBRef> albums;


        public Collection.Album GetAlbums()
        {
            var col = new Collection.Album();
            var rep = new Repository.AlbumRepository();
            return rep.GetByArtistName(name);
        }
            
    }
}
