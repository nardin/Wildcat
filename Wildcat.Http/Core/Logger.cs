using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;

namespace Wildcat.Http.Core
{
    static class Logger
    {
      private static readonly ILog log = LogManager.GetLogger(typeof(Logger));

      public static ILog Log
      {
        get { return log; }
      }

      public static void InitLogger()
      {
          XmlConfigurator.Configure();
      }
    }
}
