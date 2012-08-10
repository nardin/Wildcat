using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Wildcat.Http.Core;

namespace Wildcat.Http
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.InitLogger();

            // Веб сервер для отдачи статики
            Thread t = new Thread(HttpServer.Start);
            t.Start();
            Sys.LoadModule();

            // Веб сервис
            WSServer.Start();
            
            while (true)
            {
                Thread.Sleep(2000);
            }

        }
    }
}
