using System;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Wildcat.Http.Core
{
    class Layout : DB.System.Block
    {
        private Client _client;

        private Wildcat.DB.System.Block _block;

        public Layout(Client client)
        {
            _client = client;
        }

        public void OnEvent(string obj, string evn, JObject data)
        {
            if(obj == "Layout")
            {
                Type type = this.GetType();
                Console.WriteLine(type.FullName + ": OnEvent");
                MethodInfo mi = type.GetMethod(evn);
                if (mi.IsPublic)
                {
                    mi.Invoke(this, new object[] {data});
                }
            }
            else
            {
                int pos = obj.IndexOf('/');
                if (pos > 0)
                {
                    string subobj = obj;
                    _block.OnEvent(subobj, evn, data);
                }
                else
                {
                    _block.OnEvent(obj, evn, data);
                }
                
            }
        }

        public void OnLoad(JObject data)
        {
            Route(data.ToString());

            _block.OnInitMain(this);
            _block.OnLoad(data);
            _client.Send("Layout","OnInit",_block.GetMap());
        }

        protected void Route(string path)
        {
            Console.WriteLine("Route:"+path);
            string[] part = path.Split('/');
            string module = part[1];
            string block = part[2];
            string id = part[3];

            string blockName = module + ".Block." + block;
            Type type = Sys.blockType[blockName];
            _block = (Wildcat.DB.System.Block) type.GetConstructor(Type.EmptyTypes).Invoke(null);
            _block.Parent = this;
            _block.Name = "main";
            _block.Params.Add("id", id);

            var obj = new JObject();
            obj.Add("module",module);

            SendToClient("Layout","OnRender",obj);

        }

        public override void SendToClient(string obj, string evn, JObject data)
        {
            _client.Send(obj,evn,data);
        }
    }
}
