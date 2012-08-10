using System;
using System.Collections;
using System.Collections.Generic;

namespace Wildcat.DB.System
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Collection<T> : List<T> where T:Entity
    {

    }
}
