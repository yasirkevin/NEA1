using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Implementation1
{
    public class Visualizer
    {
        public Simulation simulation { private set; get; }
        public Graphics g { private set; get; }
        public Pen p { private set; get; }

        public Visualizer(Simulation sim, Graphics g)
        {
            this.simulation = sim;
            this.g = g;
        }

        public Color GetEntityColor(Entity entity)
        {
            string code = "";

            foreach (Gene gene in entity.genome.genes)
            {
                code += gene.code;
            }

            int splitPos = (int)Math.Round((float)(code.Length / 3));
            string[] split = new string[3] { code.Substring(0, splitPos), code.Substring(splitPos, 2 * splitPos), code.Substring(2 * splitPos, code.Length) };
            int[] values = new int[3];

            int sum = 0;
            int k = 0;
            foreach(string slice in split)
            {
                foreach(char c in slice)
                {
                    int intValue = Convert.ToInt32(Convert.ToByte(c));
                    sum += intValue;
                    values[k] = intValue;
                
                }

                k += 1;
            }

            for(int i=0; i<values.Length; i++)
            {
                values[i] = (values[i] / sum) * 255;
            }

            return Color.FromArgb(values[0], values[1], values[2]);
        }

        public void Draw()
        {
            g.Clear(Color.White);
             
            foreach (Entity entity in simulation.entities)
            {
                Color color = GetEntityColor(entity);

                p.Color = color;
                g.DrawEllipse(p, entity.position.X, entity.position.Y, 1, 1);
            }
        }

    }
}
