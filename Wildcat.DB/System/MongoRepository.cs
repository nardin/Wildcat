using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Wildcat.DB.System
{
    public abstract class MongoRepository<T> : IRepository<T> 
        where T : IEntity
    {
        private MongoDatabase _db;
        protected MongoDatabase db
        {
            get
            {
                if (_db == null)
                {
                    _db = MongoDB.Instance;
                }
                return _db;
            }
            set { }
        }

        private MongoCollection<T> _collection;
        protected MongoCollection<T> Collection
        {
            get
            {
                if (_collection == null)
                {
                    _collection = db.GetCollection<T>(typeof(T).FullName);
                }
                return _collection;
            }
        }

        public T GetById(string id)
        {
            return Collection.FindOneByIdAs<T>(new BsonObjectId(id));
        }
    }
}
