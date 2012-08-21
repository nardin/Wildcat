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
            try
            {
                JObject jObject = JObject.Parse(message);
                string obj = jObject.Property("object").Value.ToString();
                string evn = jObject.Property("event").Value.ToString();
                var data = (JObject)jObject.Property("data").Value;
                _layout.OnEvent(obj, evn, data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public void Send(string obj, string evn, string data)
        {
            JObject jObject = new JObject();
            jObject.Add("object",obj);
            jObject.Add("event",evn);
            jObject.Add("data",data);

            _socket.Send(jObject.ToString());
        }

        public void Send(string obj, string evn, JObject data)
        {
            JObject jObject = new JObject();
            jObject.Add("object", obj);
            jObject.Add("event", evn);
            jObject.Add("data", data);

            _socket.Send(jObject.ToString());
        }


        public void OnClose()
        {
            WSServer.Close(_id);
            Console.WriteLine("Close!");
        }
    }
}
