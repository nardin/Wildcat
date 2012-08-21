using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wildcat.DB.System
{
    public abstract class Setup
    {
        public abstract void OnLoad(Wildcat.DB.System.Layout layout);

        public abstract void OnUnload(Wildcat.DB.System.Layout layout);
    }
}
