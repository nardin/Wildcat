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
            var url = "ws://" + ConfigurationManager.AppSettings["ip"] + ":" +
                      ConfigurationManager.AppSettings["wsport"];

            SysConsole.WSServerUrl = url;

            var server = new WebSocketServer(url);
            server.Start(socket =>
            {
                string id = Guid.NewGuid().ToString();
                Client client = new Client(id,socket);
                clients.Add(id,client);
                SysConsole.ClientCount = clients.Count;
                SysConsole.Display();
            });
        }
        static public void Close(string id)
        {
            clients.Remove(id);
            SysConsole.ClientCount = clients.Count;
            //SysConsole.Display();
        }
    }
}
