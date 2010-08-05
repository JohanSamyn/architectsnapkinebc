using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ebc.patterns.aspects
{
    public class Log<T>
    {
        private readonly Func<T, string> createLogMessage;


        public Log(Func<T, string> createLogMessage)
        {
            this.createLogMessage = createLogMessage;
        }


        public virtual void In_Process(T data)
        {
            Write(createLogMessage(data));
            this.Out_Data(data);
        }

        public event Action<T> Out_Data= _ => { };


        private void Write(string logMessage)
        {
            Trace.TraceInformation("Logging: {0}", logMessage);
            File.AppendAllLines("log.txt", new[]{string.Format("{0}\t{1}", DateTime.Now, logMessage)});
        }
    }


    public class LogIEnumerable<T>
    {
        private readonly Func<T, string> createLogMessage;


        public LogIEnumerable(Func<T, string> createLogMessage)
        {
            this.createLogMessage = createLogMessage;
        }


        public virtual void In_Process(IEnumerable<T> dataList)
        {
            foreach(var data in dataList)
                Write(createLogMessage(data));
            this.Out_Data(dataList);
        }

        public event Action<IEnumerable<T>> Out_Data = _ => { };


        private void Write(string logMessage)
        {
            File.AppendAllLines("log.txt", new[] { string.Format("{0}\t{1}", DateTime.Now, logMessage) });
        }
    }

}