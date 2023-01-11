using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation1
{
    public class Gene
    {
        public string code { set; get; }
        public NeuronConnection connection { private set; get; }
         
        public int inputType { private set; get; }
        public int outputType { private set; get; } 
        public int weight { private set; get; }

        /// <summary>
        /// Returns a randomly generated gene, by selecting 10 random alphanumeric characters; roughly following Algorithm 5 in the report.
        /// </summary>
        /// 
        public Gene(string code, NeuronConnection connection, int weight)
        {
            this.code       = code;
            this.connection = connection;
            this.weight     = weight;
        }

        public Gene(string code, List<Neuron> sensoryColl, List<Neuron> internalColl, List<Neuron> motorColl)
        {
            int connectionType = Convert.ToInt32(code[0]); // Convert starting character to integer
            int index1 = Convert.ToInt32(code.Substring(1, 4)); // 2nd to 4th characters decide the index of the input neuron
            int index2 = Convert.ToInt32(code.Substring(5, 8)); // 6th to 8th characters decide the index of the output neuron
            int weight = Convert.ToInt32(code.Substring(9, 10)) * 4000; // The last 2 characters act as a weight, multiplied by a constant 4000
            NeuronConnection connection;


            /// 0 means the connection is Sensory --> Motor
            /// 1 means the connection is Sensory --> Internal
            /// 2 means the connection is Internal --> Internal
            /// 3 means the connection is Internal --> Motor
            /// 
            /// The modulus % so that the index is 'cyclic', and the integer is not limited.
            if (connectionType == 0)
            {
                connection = new NeuronConnection(sensoryColl[index1 % sensoryColl.Count], motorColl[index2 % motorColl.Count]);
                inputType = 0;
                outputType = 1;
            }
            else if (connectionType == 1)
            {
                connection = new NeuronConnection(sensoryColl[index1 % sensoryColl.Count], internalColl[index2 % internalColl.Count]);
                inputType = 0;
                outputType = 0;

            }
            else if (connectionType == 2)
            {
                connection = new NeuronConnection(internalColl[index1 % internalColl.Count], internalColl[index2 % internalColl.Count]);
                inputType = 1;
                outputType = 0;
            }
            else
            {
                connection = new NeuronConnection(internalColl[index1 % internalColl.Count], motorColl[index2 % motorColl.Count]);
                inputType = 1;
                outputType = 1;
            }

            this.connection = connection;
            this.weight = weight;
            this.code = code;

        }

        /// <summary>
        /// This method randomly generates a gene by selecting 10 random alphanumeric characters and a starting integer from 0 to 4 as mentioned previously
        /// </summary>
        public static Gene Rand(List<Neuron> sensoryColl, List<Neuron> internalColl, List<Neuron> motorColl)
        {
            string pool = "abcdefghijklmnopqrstuvwxyz1234567890"; // 36 possible characters to choose from
            Random rnd = new Random(); 
            string rawCode = Convert.ToString(rnd.Next(0, 3)); // The starting integer from 0 to 4 which decides type of connection

            for (int i=0; i <= 10; i++)
            {
                 rawCode = rawCode + pool[rnd.Next(pool.Length)]; // Add 10 random characters
            }


            return (new Gene(rawCode, sensoryColl, internalColl, motorColl)); // Initialise gene using the random code
        }

        /// <summary>
        /// This method re-sets the connection of the gene according to a new code (so it's used when the code is changed
        /// </summary>
        public Gene Reload(List<Neuron> sensoryColl, List<Neuron> internalColl, List<Neuron> motorColl)
        {
            return (new Gene(this.code, sensoryColl, internalColl, motorColl));
        }
    }
}
