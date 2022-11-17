using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation1
{
    public class Neuron
    {
        public Func<dynamic, int, float> operation { private set; get; }

        Neuron(Func<dynamic, int, float> operation)
        {
            this.operation = operation;
        }
    }
}
