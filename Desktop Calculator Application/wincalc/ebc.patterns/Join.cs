using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wincalc.ebc.patterns
{
    internal class ValueCollector
    {
        internal class State
        {
            public readonly HashSet<int> valuesPresent;
            public readonly object[] values;

            public State(int size)
            {
                this.valuesPresent = new HashSet<int>();
                this.values = new object[size];
            }
        }

        private readonly State state;

        public ValueCollector(int size) : this(new State(size)) { }
        internal ValueCollector(State state) { this.state = state; }


        public object this[int index]
        {
            get
            {
                return this.state.values[index];
            }

            set
            {
                this.state.valuesPresent.Add(index);
                this.state.values[index] = value;
            }
        }


        public bool Complete
        {
            get
            {
                return this.state.valuesPresent.Count() == this.state.values.Length;
            }
        }
    }


    public class Join<TInput0, TInput1>
    {
        private ValueCollector valueCollector;
        private readonly Func<TInput0, TInput1, Tuple<TInput0, TInput1>> processJoin;


        public Join()
        {
            Reset();
            this.processJoin = (a, b) => new Tuple<TInput0, TInput1>(a, b);
        }


        public void Input0(TInput0 input)
        {
            this.valueCollector[0] = input;
            JoinIfComplete();
        }

        public void Input1(TInput1 input)
        {
            this.valueCollector[1] = input;
            JoinIfComplete();
        }


        private void JoinIfComplete()
        {
            if (!this.valueCollector.Complete) return;

            this.Output(processJoin((TInput0)this.valueCollector[0],
                                    (TInput1)this.valueCollector[1]));

            Reset();
        }


        private void Reset()
        {
            this.valueCollector = new ValueCollector(2);
        }


        public Action<Tuple<TInput0, TInput1>> Output;
    }
}
