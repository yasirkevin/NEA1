using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation1
{
    public class MotorCollection
    {
        delegate void NeuronOperation(dynamic input, Entity en);

        // All of the following are simple motor neurons which move the entity (more will be added)
        static void Mvu(dynamic inp, Entity en)
        {
            if (inp != null)
            {
                en.Move(0, 1);
            }
        }
        static void Mvd(dynamic inp, Entity en)
        {
            if (inp != null)
            {
                en.Move(0, -1);
            }
        }
        static void Mvr(dynamic inp, Entity en)
        {
            if (inp != null)
            {
                en.Move(1, 0);
            }
        }
        static void Mvl(dynamic inp, Entity en)
        {
            if (inp != null)
            {
                en.Move(-1, 0);
            }
        }



        NeuronOperation[] operations = { MotorCollection.Mvr, MotorCollection.Mvl, MotorCollection.Mvu, MotorCollection.Mvd };
    }
}
