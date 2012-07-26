using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Driver;

namespace Music.Entity
{
    class Artist : Wildcat.DB.System.Entity
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
        protected IList<MongoDBRef> _sings;

        [ScaffoldColumn(false)]
        protected IList<MongoDBRef> _albums;

            
    }
}
