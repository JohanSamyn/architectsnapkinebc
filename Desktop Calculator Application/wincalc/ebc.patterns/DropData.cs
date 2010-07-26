using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wincalc.ebc.patterns
{
    class DropData<T>
    {
        public void In_Drop(T input)
        {
            this.Out_Signal();
        }

        public event Action Out_Signal;
    }
}
