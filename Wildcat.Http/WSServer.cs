using System;
using System.Collections.Generic;
using Fleck;
using Wildcat.Http.Core;
using System.Configuration;

namespace Wildcat.Http
{
    class WSServer
    {
        static Dictionary<string, Core.Client> clients = new Dictionary<string, Client>();

        static public void Start()
        {

            var server = new WebSocketServer("ws://" + ConfigurationManager.AppSettings["ip"] + ":" + ConfigurationManager.AppSettings["wsport"]);
            server.Start(socket =>
            {
                string id = Guid.NewGuid().ToString();
                Client client = new Client(id,socket);
                clients.Add(id,client);
                Console.WriteLine("Всего подключенных клиентов :" + clients.Count);
            });
        }
        static public void Close(string id)
        {
            clients.Remove(id);
            Console.WriteLine("Всего подключенных клиентов :" + clients.Count);
        }
    }
}
