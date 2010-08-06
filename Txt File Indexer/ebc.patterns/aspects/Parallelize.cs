using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ebc.patterns.aspects
{
    public class Parallelize<T>
    {
        public void In_Process(T data)
        {
            ThreadPool.QueueUserWorkItem(_ => this.Out_ProcessInParallel((T)_), data);
        }

        public event Action<T> Out_ProcessInParallel;
    }
}
