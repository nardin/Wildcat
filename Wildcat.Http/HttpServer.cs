using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Configuration;

namespace Wildcat.Http
{
    class HttpServer
    {
        TcpListener Listener; // Объект, принимающий TCP-клиентов

        // Запуск сервера
        public HttpServer(int Port)
        {
            Core.Logger.Log.Info("Старт сервера статики");
            Listener = new TcpListener(IPAddress.Any, Port); // Создаем "слушателя" для указанного порта
            Listener.Start(); // Запускаем его
            Listener.Server.ReceiveTimeout = 1000;
            Listener.Server.SendTimeout = 1000;

            // В бесконечном цикле
            while (true)
            {
                // Принимаем новых клиентов. После того, как клиент был принят, он передается в новый поток (ClientThread)
                // с использованием пула потоков.
                ThreadPool.QueueUserWorkItem(new WaitCallback(ClientThread), Listener.AcceptTcpClient());

                /*
                // Принимаем нового клиента
                TcpClient Client = Listener.AcceptTcpClient();
                // Создаем поток
                Thread Thread = new Thread(new ParameterizedThreadStart(ClientThread));
                // И запускаем этот поток, передавая ему принятого клиента
                Thread.Start(Client);
                */
            }
        }

        static void ClientThread(Object StateInfo)
        {
            // Просто создаем новый экземпляр класса Client и передаем ему приведенный к классу TcpClient объект StateInfo
            try
            {
                new HttpClient((TcpClient)StateInfo);
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e.Message);
            }

            
        }

        // Остановка сервера
        ~HttpServer()
        {
            // Если "слушатель" был создан
            if (Listener != null)
            {
                // Остановим его
                Listener.Stop();
            }
        }

        public static void Start()
        {
            // Определим нужное максимальное количество потоков
            // Пусть будет по 4 на каждый процессор
            int MaxThreadsCount = Environment.ProcessorCount * 8;
            // Установим максимальное количество рабочих потоков
            ThreadPool.SetMaxThreads(MaxThreadsCount, MaxThreadsCount);
            // Установим минимальное количество рабочих потоков
            ThreadPool.SetMinThreads(4, 4);
            // Создадим новый сервер на порту 80
            new HttpServer(Convert.ToInt32(ConfigurationManager.AppSettings["port"]));
        }
        
    }
}
