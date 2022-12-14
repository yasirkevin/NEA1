using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation1
{
    public class InternalCollection
    {
        delegate float NeuronOperation(dynamic input, float weight);

        // All of the following are simple internal neurons which just apply a trigonometrical function on the input sum and forward it to the next neuron.
        static float Hyptan(dynamic input, float weight)
        {
            return (Math.Tanh(input.Sum()));
        }

        static float Hypcos(dynamic input, float weight)
        {
            return (Math.Cosh(input.Sum()));
        }

        static float Hypsin(dynamic input, float weight)
        {
            return (Math.Sinh(input.Sum()));
        }

        NeuronOperation[] operations = { InternalCollection.Hyptan, InternalCollection.Hypcos, InternalCollection.Hypsin };
    }
}
