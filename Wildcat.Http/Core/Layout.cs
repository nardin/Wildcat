using System;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Wildcat.Http.Core
{
    class Layout : DB.System.Block
    {
        private Client _client;

        private dynamic _block;

        public Layout(Client client)
        {
            _client = client;
        }

        public void OnEvent(string obj, string evn, JProperty data)
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
                    string subobj = obj.Substring(obj.IndexOf('/'));
                    _block.OnEvent(subobj, evn, data);
                }
            }
        }

        public void OnLoad(JProperty data)
        {
            string blockName = Route(data.Value.ToString());

            Type type = Sys.blockType[blockName];
            _block = type.GetConstructor(Type.EmptyTypes).Invoke(null);
            _block.OnInit(this);
            _block.OnLoad(data);
            _client.Send("Layout","OnLoad",_block.GetMap().ToString());
        }

        protected string Route(string path)
        {
            Console.WriteLine("Route:"+path);
            string[] part = path.Split('/');
            string module = part[1];
            string block = part[2];
            string id = part[3];

            return module + ".Block." + block;
        }
    }
}
