using System;
using MongoDB.Driver;
using Music.Entity;

namespace Music.Repository
{
    public class ArtistRepository : Wildcat.DB.System.MongoRepository<Entity.Artist>
    {
        public Artist GetByUrl(string url)
        {
            var query = new QueryDocument("url", url);
            Artist artist = Collection.FindOne(query);
            return artist;
        }

        public Collection.Artist GetAll()
        {
            var col = new Collection.Artist();
            MongoCursor<Entity.Artist> cursor = Collection.FindAll();
            foreach (var artist in cursor)
            {
                col.Add(artist);
            }
            return col;
        }
    }
}
