using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Implementation1
{
    public class SensoryCollection
    {
        delegate float NeuronOperation(dynamic input, Entity en);

        /// <summary>
        /// Sensory neuron that returns random number between 0 and 1
        /// </summary>
        static float Rnd(dynamic general, Entity en)
        {
            Random rnd = new Random();

            return (rnd.Next(0, 1));
        }

        /// <summary>
        /// Sensory neuron that checks the population density in the forward direction.
        /// </summary>
        static float Pdn(dynamic general, Entity en)
        {
            Map map = general.map;
            Vector2 forwardDirection = en.GetForward();
            Vector2 position = en.position;
            int pop = 0;
            int blocks = 0;

            while(true)
            {
                if (position.X == 0 || position.Y == 0 || position.X == map.map.GetLength(0) || position.Y == map.map.GetLength(1))
                {
                    break; // We have reached the minimum or maximum positions in the grid (cannot exceed size)
                }

                if (map.map[(int)position.X, (int)position.Y] != null && map.map[(int)position.X, (int)position.Y] != en)
                {
                    pop++; // Found entity in the current position
                }

                position += forwardDirection; // Add the forward direction to the current position to get next position.
                blocks++; // Keep track of number of blocks checked through
            }

            return (pop / blocks); // This returns a value between 0 and 1 indicating number of entities per block in the forward direction
        }

        /// <summary>
        /// Sensory neuron that returns net change in movement.
        /// </summary>
        static float Lst(dynamic general, Entity en)
        {
            return ((en.position - en.lastPosition).Length());
        }

        /// The following 4 methods are sensory neurons returning distances from each side of the map.
        /// We get distance then divide by max. distance to normalize it between 0 and 1
        static float Dir(dynamic general, Entity en)
        {
            return ((general.map.GetLength(0) - en.position.X) / general.map.GetLength(0)); 
        }

        static float Dil(dynamic general, Entity en)
        {
            return (en.position.X / general.map.GetLength(0));
        }
        static float Diu(dynamic general, Entity en)
        {
            return (en.position.Y / general.map.GetLength(0));
        }
        static float Dib(dynamic general, Entity en)
        {
            return ((general.map.GetLength(0) - en.position.Y) / general.map.GetLength(0));
        }

        /// Following 2 methods are sensory neurons returning change in respective X or Y positions.
        static float Lmx(dynamic general, Entity en)
        {
            return ((en.position.X - en.lastPosition.X));
        }
        static float Lmy(dynamic general, Entity en)
        {
            return ((en.position.Y - en.lastPosition.Y));
        }

        /// <summary>
        /// This sensory neuron acts as an oscillator; its value oscillates between 0 and 1 symmetrically with time.
        /// </summary>
        static float Osc(dynamic general, Entity en)
        {
            return ((float)Math.Sin(en.age));
        }

        NeuronOperation[] operations = { SensoryCollection.Rnd, SensoryCollection.Pdn, SensoryCollection.Dib, SensoryCollection.Dir, SensoryCollection.Dil, SensoryCollection.Diu, SensoryCollection.Osc, SensoryCollection.Lmx, SensoryCollection.Lmy, SensoryCollection.Lst};
    }
}
