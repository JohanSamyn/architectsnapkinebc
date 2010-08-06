using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ebc.patterns.aspects
{
    public class Asynchronize<T>
    {
        private readonly Thread worker;

        private readonly Queue<T> dataToProcess;
        private readonly AutoResetEvent dataAvailable;


        public Asynchronize()
        {
            this.dataToProcess = new Queue<T>();
            this.dataAvailable = new AutoResetEvent(false);

            this.worker = new Thread(DispatchDataSequentially) {IsBackground = true};
            this.worker.Start();
        }


        private void DispatchDataSequentially()
        {
            while (true)
            {
                this.dataAvailable.WaitOne();

                T data;
                while (TryGetDataToDispatch(out data))
                {
                    this.Out_ProcessSequentially(data);
                }
            }
        }


        private bool TryGetDataToDispatch(out T data)
        {
            data = default(T);

            lock (this.dataToProcess)
            {
                if (this.dataToProcess.Count() == 0) return false;

                data = this.dataToProcess.Dequeue();
                return true;
            }
        }


        public void In_Process(T data)
        {
            lock (this.dataToProcess)
            {
                this.dataToProcess.Enqueue(data);
            }
            this.dataAvailable.Set();
        }


        public event Action<T> Out_ProcessSequentially;
    }
}
