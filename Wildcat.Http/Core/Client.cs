using System;
using Fleck;

namespace Wildcat.Http.Core
{
    class Client
    {
        private IWebSocketConnection _socket;
        private string _id;

        public Client(string id, IWebSocketConnection socket)
        {
            _socket = socket;
            _id = id;

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
            _socket.Send(message);
        }

        public void OnClose()
        {
            WSServer.Close(_id);
            Console.WriteLine("Close!");
        }
    }
}
