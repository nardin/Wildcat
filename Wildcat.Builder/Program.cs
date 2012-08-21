using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wildcat.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                return;
            }
            var pathSrc = args[0];
            var pathBuild = args[1];
            var builder = new Builder(pathSrc, pathBuild);
            builder.Do();
        }
    }
}
