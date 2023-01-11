using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;

namespace Implementation1
{
    public enum SimulationState
    {
        Generating,
        Idle,
        Running,
        Paused,
        Finished,
    }

    public class Simulation
    {
        public List<Entity> entities { private set; get;}
        public List<dynamic> otherObjects { private set; get; }
        public Map map { private set; get; }
        public int startPopulation { private set; get; }
        public int maxPopulation { private set; get;}
        public int generation { private set; get; }
        public int generationStep { private set; get; }
        public SimulationState state { private set; get; }
        public Visualizer visualizer { private set; get; }

       

        public Simulation(int startPopulation, int maxPopulation, int mapSizeX, int mapSizeY, Graphics g)
        {
            entities                = new List<Entity>();
            otherObjects            = new List<dynamic>();
            map                     = new Map(mapSizeX, mapSizeY);
            visualizer              = new Visualizer(this, g);

            this.startPopulation    = startPopulation;
            this.maxPopulation      = maxPopulation;

            generationStep = 0;
            generation = 0;
        }

        public void Generate(int genomeSize, List<Neuron> sensoryColl, List<Neuron> internalColl, List<Neuron> motorColl)
        {
            Random rand = new Random();
            state = SimulationState.Generating;
                
            for(int i = 0; i <= startPopulation; i++)
            {
               
                Genome genome = Genome.Rand(genomeSize, sensoryColl, internalColl, motorColl);
                Entity entity = new Entity(genome, new Vector2(rand.Next(1, map.sizeX), rand.Next(1, map.sizeY)), map);
                
                entities.Add(entity);
                map.set(entity.position, entity);
            }

            state = SimulationState.Idle;
        }

        public void Resume()
        {

        }

        public void Pause()
        {

        }
    }
}
