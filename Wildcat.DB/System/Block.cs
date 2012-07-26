using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Wildcat.DB.System
{
    public class Block
    {
        protected Block Parent;

        protected List<Block> Blocks = new List<Block>();


        public void OnLoad(JProperty data)
        {
            Type type = this.GetType();
            Console.WriteLine(type.FullName + ": OnLoad");
            foreach (var childBlock in Blocks)
            {
                childBlock.OnLoad(data);
            }
        }

        public virtual void OnInit(Block block)
        {
            Parent = block;
            foreach (var childBlock in Blocks)
            {
                childBlock.OnInit(this);
            }
            Type type = this.GetType();
            Console.WriteLine(type.FullName + ": OnInit");
        }

        public void OnEvent(string evn, string data)
        {
            Type type = this.GetType();
            Console.WriteLine(type.FullName + ": OnEvent");
            MethodInfo mi = type.GetMethod(evn);
            Console.WriteLine(mi.IsPublic);
            mi.Invoke(this, new object[] {data});
        }

        public JObject GetMap()
        {
            JArray list = new JArray();
            foreach (Block childBlock in Blocks)
            {
                list.Add(childBlock.GetMap());
            }
            Type type = this.GetType();
 
            JObject jObject = new JObject();
            JToken jToken = list;
            jObject.Add(type.FullName, list); 
            return jObject;
        }



    }
}
