using System;
using System.Collections.Generic;
using System.Reflection;


namespace Wildcat.Http.Core
{
    static class Sys
    {
        public static Dictionary<string, Type> blockType;

        static public void LoadModule()
        {
            blockType = new Dictionary<string, Type>();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("==Load Modules==");


            Assembly assembly = Assembly.LoadFrom("Music.dll");
            Console.WriteLine(assembly.FullName);
            Type[] types = assembly.GetTypes();
            char[] delimiter = ".".ToCharArray();

            foreach (Type type in types)
            {
                string[] name = type.Namespace.Split(delimiter);
                switch (name[1])
                {
                    case "Block":
                        string blockName = type.FullName;
                        blockType[blockName] =  type;
                        Console.WriteLine("Load Block: " + blockName);
                        break;
                }
            }
            Console.WriteLine("Total block: "+blockType.Count);
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
