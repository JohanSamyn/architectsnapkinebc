using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ebc.patterns.aspects
{
    public class Validate<T>
    {
        private readonly Func<T, bool> validateData;
        private readonly Func<T, string> describeInvalidSituation;


        public Validate(Func<T, bool> validateData, Func<T, string> describeInvalidSituation)
        {
            this.validateData = validateData;
            this.describeInvalidSituation = describeInvalidSituation;
        }


        public void In_Validate(T data)
        {
            Trace.TraceInformation("Validating {0}", data.GetType().ToString());
            if (validateData(data))
                this.Out_ValidData(data);
            else
            {
                Trace.TraceWarning("Validation failed for {0}", data.GetType().ToString());
                this.Out_InvalidData(describeInvalidSituation(data));
            }
        }


        public event Action<T> Out_ValidData;
        public event Action<string> Out_InvalidData = _ => { };
    }
}
