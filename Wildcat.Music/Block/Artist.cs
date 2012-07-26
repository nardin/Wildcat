using System;
using Newtonsoft.Json.Linq;

namespace Music.Block
{
    class Artist : Wildcat.DB.System.Block
    {
        protected string name;
        #region События

        public override void OnInit(Wildcat.DB.System.Block block)
        {
            base.OnInit(block);
            Albums albums = new Albums();
            albums.OnInit(this);
            Blocks.Add(albums);
        }

        public void OnSetName(string data)
        {
            name = data;
        }

        public void OnPrintName(string data)
        {
            Console.WriteLine("---------"+name);
        }
        #endregion
    }
}
