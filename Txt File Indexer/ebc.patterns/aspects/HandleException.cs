using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ebc.patterns.aspects
{
    public class HandleException<T>
    {
        public void In_Process(T data)
        {
            try
            {
                this.Out_Process(data);
            }
            catch (Exception ex)
            {
                this.Out_Exception(ex);
            }
        }


        public event Action<T> Out_Process;
        public event Action<Exception> Out_Exception = _ => { };
    }
}
