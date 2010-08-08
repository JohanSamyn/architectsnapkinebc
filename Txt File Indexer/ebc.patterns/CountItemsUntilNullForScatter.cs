using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace ebc.patterns
{
    public class CountItemsUntilNullForScatter<T> where T : class
    {
        private int counter = 0;


        public void In_Count(T item)
        {
            if (item == null)
            {
                Trace.TraceInformation("CountUntilNull({0}) [Thread {1}]", this.counter, Thread.CurrentThread.GetHashCode());

                this.Out_Count(this.counter);
                this.counter = 0;
            }
            else
            {
                this.counter++;
                this.Out_Counted(item);
            }
        }


        public event Action<T> Out_Counted;
        public event Action<int> Out_Count;
    }
}
