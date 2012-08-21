using System;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Wildcat.DB.System
{
    public abstract class Layout : DB.System.Block
    {
        public abstract void OnEvent(string obj, string evn, JObject data);

        public abstract void OnLoad(JObject data);

        protected abstract void Route(string path);

        public abstract override void SendToClient(string obj, string evn, JObject data);
    }
}
