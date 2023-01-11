using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Implementation1
{
    public class Entity
    {
        public Genome genome { private set; get; }
        public Vector2 position { private set; get; }
         
        public Vector2 lastPosition { private set; get; }
        public int age { private set; get; } // Age is incremented by 1 every step in a generation

        public Map map { private set; get; }

        public Entity(Genome genome, Vector2 position, Map map)
        {
            this.genome     = genome;
            this.position   = position;
            this.map        = map;

            this.age            = 0;
            this.lastPosition   = position;
        }

        /// <summary>
        /// This returns the forward direction of the entity: by forward I mean the difference between the current position and last position
        /// </summary>
        /// <returns></returns>
        public Vector2 GetForward()
        {
            Vector2 dir = (this.position - this.lastPosition); // Get difference in positions

            if (dir.Length() > 0) // There was a difference, so return that as it is a direction
            {
                return (dir);
            }
            else // The entity still hasn't moved from its starting position so I make up a direction
            {
                return (new Vector2(0, 1));
            }

        }

        /// <summary>
        /// This moves the entity by specified change through the map.
        /// </summary>
        /// <param name="change"></param>
        public void Move(Vector2 change)
        {
            Vector2 newPos = this.position + change; // Add the change to current position
            if (newPos.X > this.map.map.GetLength(0) || newPos.Y > this.map.map.GetLength(1) || newPos.X < 0 || newPos.Y < 0) // The new position cannot be below 0 or above the bounds of the map
            {
                return;
            }

            this.lastPosition = this.position;
            this.position = newPos;
            this.map.change(this.lastPosition, this.position, this);
        }

        public void Move(int x, int y) { Move(new Vector2(x, y)); }

        /// <summary>
        /// This uses the Crossover method from the current Genome with the target Genome to mix the genes of the specified entities, acting as a form of reproduction.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public Entity Reproduce(Entity target)
        {
            Random rand = new Random();
            Entity newEntity = new Entity(
                this.genome.Crossover(target.genome),
                new Vector2(rand.Next(0, this.map.map.GetLength(0)), rand.Next(0, this.map.map.GetLength(1))), // Select random starting position for the new entity
                this.map
            );

            return (newEntity);


        }

        public void Mutate(List<Neuron> sensoryColl, List<Neuron> internalColl, List<Neuron> motorColl)
        {
            Random rand = new Random();
            string pool = "abcdefghijklmnopqrstuvwxyz1234567890"; // We use the pool of 36 characters again

            int randInt = rand.Next(0, this.genome.genes.Count); // Select random gene in the genome
            Gene randomGene = this.genome.genes[rand.Next(0, randInt)]; // Select random character in the gene
            char[] code = randomGene.code.ToCharArray(); // Convert to a character array in order to change the selected character

            code[rand.Next(0, code.Length)] = pool[rand.Next(0, pool.Length)]; // Randomly change it using random character
            randomGene.code = code.ToString();
            this.genome.genes[randInt] = randomGene.Reload(sensoryColl, internalColl, motorColl); // Reload the gene as the code has been changed.
        }

    }
}
