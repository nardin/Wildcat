using System;
using Music.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Music.Block
{
    class Artist : Wildcat.DB.System.Block
    {
        public Entity.Artist Model;
   

        #region События


        public override void OnInitMain(Wildcat.DB.System.Block block)
        {
            if(Params.ContainsKey("id"))
            {
                Repository.ArtistRepository repository = new ArtistRepository();
                Model = repository.GetByUrl(Params["id"]);
            }


            Albums albums = new Albums();
            albums.Parent = this;
            albums.Name = "albums";
            Blocks.Add(albums.Name, albums);
            base.OnInitMain(block);
        }

        public virtual void OnLoadData(JObject data)
        {

            if (Model != null)
            {
                var jObj = JObject.FromObject(Model);
                Console.WriteLine(jObj.ToString());
                SendToClient("OnLoadData", jObj);
            }

        }

        #endregion
    }
}
