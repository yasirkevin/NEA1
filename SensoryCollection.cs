using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Implementation1
{
    public class SensoryCollection
    {
        delegate float NeuronOperation(dynamic input, float weight);

        static float Rnd(dynamic general, Entity en)
        {
            Random rnd = new Random();

            return (rnd.Next(0, 1));
        }

        static float Pdn(dynamic general, Entity en)
        {
            Map map = general.map;
            Vector2 forward = en.getForward();


        }

        NeuronOperation[] operations = { InternalCollection.Hyptan };
    }
}
