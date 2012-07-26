using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wildcat.DB.System
{
    interface ICollection<T> : IList<T> where T:IEntity
    {
    }
}
