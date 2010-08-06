using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ebc.patterns
{
    public class InsertNullAfterItemsForGather<T> where T : class
    {
        private int numberOfItemsToGather;
        private int count;


        public void In_Process(T item)
        {
            this.Out_Gather(item);

            lock (this)
            {
                this.count++;
                if (this.count >= this.numberOfItemsToGather)
                {
                    this.Out_Gather(null);
                    this.count = 0;
                }
            }
        }


        public void In_NumberOfItemsToGather(int numberOfItemsToGather)
        {
            lock (this)
            {
                this.numberOfItemsToGather = numberOfItemsToGather;
            }
        }


        public event Action<T> Out_Gather;
    }
}
