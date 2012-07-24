using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace Wildcat.DB.System
{
    public interface IEntity
    {
        [BsonId]
        string Id { get; set; }
    }
}
