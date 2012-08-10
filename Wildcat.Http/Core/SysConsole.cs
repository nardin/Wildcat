using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Wildcat.Http.Core
{
    static class  SysConsole
    {
        public static int ClientCount = 0;
        public static string StaticServerUrl = "";
        public static string WSServerUrl = "";

        public static  List<string> Modules = new List<string>();
        public static List<string> Blocks = new List<string>();

        public static void Display()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Wildcat Http");

            Console.WriteLine("==Загруженные модули==");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (string module in Modules)
            {
                Console.WriteLine(module);
            } 
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("=======================");

            Console.WriteLine("==Загруженные блоки==");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (string block  in Blocks)
            {
                
                Console.WriteLine(block);
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("=======================");

            Process proc = Process.GetCurrentProcess();
            Console.Write("Памяти используеться:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(Math.Round((double)proc.PrivateMemorySize64/(1024*1024)));
            Console.WriteLine(" Mb");
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.Write("Время работы:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(DateTime.Now.Subtract(proc.StartTime).Minutes);
            Console.WriteLine(" минут");
            Console.ForegroundColor = ConsoleColor.DarkGreen;


            Console.Write("Подключений: ");
            Console.ForegroundColor = ConsoleColor.White;                
            Console.WriteLine(ClientCount);
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
