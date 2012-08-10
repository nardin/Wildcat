using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Music.Block
{
    class Artists : Wildcat.DB.Block.List
    {
        public Collection.Artist Model;

        public override void OnInitMain(Wildcat.DB.System.Block block)
        {
            base.OnInitMain(block);
        }

        public override void OnInitSmall(Wildcat.DB.System.Block block)
        {
            base.OnInitSmall(block);
        }

        public void OnLoadData(JObject data)
        {
            var rep = new Repository.ArtistRepository();
            Model = rep.GetAll();
            foreach (Entity.Artist artist in Model)
            {
                var block = new Artist();
                block.OnInitSmall(this);
                block.Model = artist;
                block.Name = artist.Id;
                Blocks.Add(artist.Id, block);
            }

            var map = GetMap();
            SendToClient("OnAddBlocks",map);


        }
    }
}
