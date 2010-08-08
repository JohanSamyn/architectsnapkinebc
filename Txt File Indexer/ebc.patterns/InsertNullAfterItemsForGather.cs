using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Trace.TraceInformation("Passed on item to gather");

            this.Out_Gather(item);

            lock (this)
            {
                this.count++;
                IssueNull();
            }
        }


        public void In_NumberOfItemsToGather(int numberOfItemsToGather)
        {
            lock (this)
            {
                Trace.TraceInformation("Number of items to gather: {0}", numberOfItemsToGather);

                this.numberOfItemsToGather = numberOfItemsToGather;
                IssueNull();
            }
        }


        private void IssueNull()
        {
            if (this.count >= this.numberOfItemsToGather)
            {
                Trace.TraceInformation("Gathered enough items ({0}); issueing null", numberOfItemsToGather);

                this.Out_Gather(null);
                this.count = 0;
            }
        }


        public event Action<T> Out_Gather;
    }
}
