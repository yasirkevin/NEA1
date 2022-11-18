using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation1
{
    public class NeuronConnection
    {
        public Neuron input { private set; get; }
        public Neuron output { private set; get; }
        public NeuronConnection(Neuron input, Neuron output)
        {
            this.input = input;
            this.output = output;
        }
    }
}
