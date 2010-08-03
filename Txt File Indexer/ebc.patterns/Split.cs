using System;

namespace ebc.patterns
{
    public class Split<TInput, TOutput0, TOutput1>
    {
        private readonly Func<TInput, TOutput0> splitOff0;
        private readonly Func<TInput, TOutput1> splitOff1;

        public Split(Func<TInput, TOutput0> splitOff0, Func<TInput, TOutput1> splitOff1)
        {
            this.splitOff0 = splitOff0;
            this.splitOff1 = splitOff1;
        }


        public void Input(TInput message)
        {
            this.Output0(this.splitOff0(message));
            this.Output1(this.splitOff1(message));
        }


        public Action<TOutput0> Output0;
        public Action<TOutput1> Output1;
    }


    public class Split<TInput, TOutput0, TOutput1, TOutput2>
    {
        private readonly Func<TInput, TOutput0> splitOff0;
        private readonly Func<TInput, TOutput1> splitOff1;
        private readonly Func<TInput, TOutput2> splitOff2;

        public Split(Func<TInput, TOutput0> splitOff0, Func<TInput, TOutput1> splitOff1, Func<TInput, TOutput2> splitOff2)
        {
            this.splitOff0 = splitOff0;
            this.splitOff1 = splitOff1;
            this.splitOff2 = splitOff2;
        }


        public void Input(TInput message)
        {
            this.Out0(this.splitOff0(message));
            this.Out1(this.splitOff1(message));
            this.Out2(this.splitOff2(message));
        }


        public Action<TOutput0> Out0;
        public Action<TOutput1> Out1;
        public Action<TOutput2> Out2;
    }

}
