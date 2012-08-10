using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Wildcat.DB.System
{
    /// <summary>
    /// Базовый класс блоков
    /// </summary>
    public abstract class Block
    {
        protected object Model;

        public BlockState State;

        public Dictionary<string,string> Params = new Dictionary<string, string>();

        public string Name;

        public Block Parent;

        protected Dictionary<string, Block> Blocks = new Dictionary<string, Block>();

        protected void AddChildBlock(string name, ref Block block)
        {
            block.Parent = this;
            block.Name = name;
            Blocks.Add(name, block);
        }


        public void OnLoad(JObject data)
        {
            Type type = GetType();
            Console.WriteLine(type.FullName + ": OnLoad");
            foreach (var childBlock in Blocks.Values)
            {
                childBlock.OnLoad(data);
            }
        }

        public virtual void OnInitSmall(Block block)
        {
            Parent = block;
            State = BlockState.Small;
            foreach (var childBlock in Blocks.Values)
            {
                childBlock.OnInitSmall(this);
            }
            Type type = GetType();
            Console.WriteLine(type.FullName + ": OnInit");
        }

        public virtual void OnInitMain(Block block)
        {
            Parent = block;
            State = BlockState.Main;
            foreach (var childBlock in Blocks.Values)
            {
                childBlock.OnInitSmall(this);
            }
            Type type = GetType();
            Console.WriteLine(type.FullName + ": OnInit");
        }

        public virtual void OnInitMainMini(Block block)
        {
            Parent = block;
            State = BlockState.Mini;
            foreach (var childBlock in Blocks.Values)
            {
                childBlock.OnInitSmall(this);
            }
            Type type = GetType();
            Console.WriteLine(type.FullName + ": OnInit");
        }



        public void OnEvent(string obj, string evn, JObject data)
        {
            if(obj == Name)
            {
                Type type = GetType();
                Console.WriteLine(type.FullName + ": OnEvent");
                MethodInfo mi = type.GetMethod(evn);
                if (mi != null)
                {
                    mi.Invoke(this, new object[] {data});
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(evn);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            int pos = obj.IndexOf('/');
            if (pos > 0)
            {
                string subobj = obj.Substring(obj.IndexOf('/')+1);
                Blocks[subobj].OnEvent(subobj, evn, data);
            }
        }


        public virtual void SendToClient(string obj, string evn, JObject data)
        {
            if (obj != "")
            {
                obj = "/" + obj;
            }
            obj = Name + obj;
            Parent.SendToClient(obj, evn,data);
        }

        protected void SendToClient(string evn, JObject data)
        {
            SendToClient("", evn, data);
        }

        public JObject GetMap()
        {
            var list = new JArray();
            foreach (Block childBlock in Blocks.Values)
            {
                list.Add(childBlock.GetMap());
            }
            Type type = GetType();

            var jObject = new JObject();
            jObject.Add("name", Name);
            jObject.Add("class", type.FullName);
            jObject.Add("state",State.ToString());
            jObject.Add("child", list);
            
            return jObject;
        }


        public enum BlockState
        {
            Main,
            Small,
            Mini
        }
    }
}
