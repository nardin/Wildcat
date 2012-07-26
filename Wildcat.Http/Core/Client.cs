using System;
using Fleck;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Wildcat.Http.Core
{
    class Client
    {
        private IWebSocketConnection _socket;
        private string _id;
        private Layout _layout;

        protected dynamic _block;

        public Client(string id, IWebSocketConnection socket)
        {
            _socket = socket;
            _id = id;

            _layout = new Layout(this);

            socket.OnOpen = OnOpen;
            socket.OnClose = OnClose;
            socket.OnMessage = OnMessage;
        }

        public void OnOpen()
        {
            Console.WriteLine("Open!");
        }

        public void OnMessage(string message)
        {
            Console.WriteLine(message);
            JObject jObject = JObject.Parse(message);
            string obj = jObject.Property("object").Value.ToString();
            string evn = jObject.Property("event").Value.ToString();
            JProperty data = jObject.Property("data");

            _layout.OnEvent(obj,evn,data);


            /*if (obj == "client")
            {
                switch (evn)
                {
                    case "load":
                        Type type = Sys.blockType[data];
                        _block = type.GetConstructor(Type.EmptyTypes).Invoke(null);
                        _block.OnLoad();
                        break;
                }
            }
            if (obj == "block")
            {
                _block.OnEvent(evn, data);
            }*/

            //_socket.Send(message);
        }
        public void Send(string obj, string evn, string data)
        {
            _socket.Send(data);
        }


        public void OnClose()
        {
            WSServer.Close(_id);
            Console.WriteLine("Close!");
        }
    }
}
