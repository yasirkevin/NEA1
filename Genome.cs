using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation1
{
    public class Genome
    {
        public List<Gene> genes { private set; get; } // The genome class stores a list of genes, and adds a few helper methods

       
        public Genome(List<Gene> genes)
        {
            this.genes = genes;
        }

        public Genome()
        {
            this.genes = new List<Gene>();
        }

        /// <summary>
        /// Randomly generates a Genome of the specified length using the Rand() method of Gene.
        /// </summary>
        /// <returns></returns>
        public static Genome Rand(int length, List<Neuron> sensoryColl, List<Neuron> internalColl, List<Neuron> motorColl)
        {
            List<Gene> genes = new List<Gene>(); // Initialise empty list of neurons

            for(int i = 0; i <= length; i++)
            {
                genes.Add(Gene.Rand(sensoryColl, internalColl, motorColl)); // Add randomly generated gene to the list
            }

            return (new Genome(genes));
        }
         
        /// <summary>
        /// This method returns a Genome with mixed genes from the current Genome and the target Genome.
        /// </summary>
        public Genome Crossover(Genome target)
        {
            Genome newGenome = new Genome();
            Random rnd = new Random();
            int mid = rnd.Next(this.genes.Count); // Select a random midpoint in the size of the genome

            for(int i = 0; i <= mid; i++) // The first half (from 1 to midpoint) will consist of 1st parent's genes
            {
                newGenome.Add(this.genes[i]);
            }

            for(int i = mid; i <= this.genes.Count; i++) // The other half are the 2nd parent's genes.
            {
                newGenome.Add(target.genes[i]);
            }

            return (newGenome);
        }

        
        /// <summary>
        /// Adds a gene to the genome (would usually be used with an empty genome)
        /// </summary>
        /// <param name="g"></param>
        public void Add(Gene g)
        {
            this.genes.Add(g);
        }
    }
}
