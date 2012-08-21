using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Music.Block
{
    public class Albums : Wildcat.DB.System.Block
    {
        public new Collection.Album Model;

        public override void OnInitSmall(Wildcat.DB.System.Block block)
        {
            var parent = (Block.Artist)Parent;
            Model = parent.Model.GetAlbums();
            State = BlockState.Small;
        }

        public void OnLoadData(JObject data)
        {
            if (Model != null)
            {
                var jObj = new JObject();
                jObj.Add("collection", JArray.FromObject(Model));

                Console.WriteLine(jObj.ToString());
                SendToClient("OnLoadData", jObj);
            }
        }
    }
}
