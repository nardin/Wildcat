using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using Music.Entity;

namespace Music.Repository
{
    class AlbumRepository : Wildcat.DB.System.MongoRepository<Entity.Album>
    {
        public Album GetByUrl(string url)
        {
            var query = new QueryDocument("url", url);
            Album album = Collection.FindOne(query);
            return album;
        }

        public Collection.Album GetByArtistName(string name)
        {
            var col = new Collection.Album();

            var query = new QueryDocument("artist", name);
            MongoCursor<Entity.Album> cursor = Collection.Find(query);
            foreach (var album in cursor)
            {
                col.Add(album);
            }
            return col;
        }
    }
}
