using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace ebc.patterns.aspects
{
    public class SwitchBackToSyncContext<T>
    {
        private readonly SynchronizationContext ctx = SynchronizationContext.Current;


        public SwitchBackToSyncContext() : this(SynchronizationContext.Current) { }
        internal SwitchBackToSyncContext(SynchronizationContext ctx)
        {
            this.ctx = ctx;
        }


        public void In_Process(T msg)
        {
            if (this.ctx != null)
                this.ctx.Send(x =>
                {
                    Trace.TraceInformation("Switching back to sync ctx: {0}", msg.GetType().Name);
                    this.Out_ContinueInSyncContext(msg);
                }, null);
            else
            {
                Trace.TraceInformation("No syn ctx switch back: {0}", msg.GetType().Name);
                this.Out_ContinueInSyncContext(msg);
            }
        }


        public event Action<T> Out_ContinueInSyncContext;


        public static Action<T> Wrap(Action<T> continuation)
        {
            var switchBack = new SwitchBackToSyncContext<T>();
            switchBack.Out_ContinueInSyncContext += continuation;
            return switchBack.In_Process;
        }
    }
}
