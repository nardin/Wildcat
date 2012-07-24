using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Wildcat.Http
{
    class Program
    {
        static void Main(string[] args)
        {
            // Веб сервер для отдачи статики
            Thread t = new Thread(HttpServer.Start);
            t.Start();
            WSServer.Start();
            while (true)
            {
                Thread.Sleep(2000);
            }

        }
    }
}
