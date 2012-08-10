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

            Assembly assembly = Assembly.LoadFrom("Music.dll");
            SysConsole.Modules.Add(assembly.FullName);
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
                        SysConsole.Blocks.Add(blockName);
                        break;
                }
            }
        }

    }
}
