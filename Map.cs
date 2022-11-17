using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
namespace Implementation1
{
    class Map
    {
        public dynamic[,] map { private set; get; }
    
        public Map(int sizeX, int sizeY)
        {
            this.map = new dynamic[sizeX, sizeY];
        }

        public void set(int posX, int posY, dynamic obj)
        {
            if (posX > this.map.GetLength(0) || posY > this.map.GetLength(1))
            {
                throw new ArgumentException();
            }

            map[posX, posY] = obj;
        }

        public void set(Vector2 pos, dynamic obj) { this.set((int)pos.X, (int)pos.Y, obj); }

        public void change(Vector2 pos1, Vector2 pos2, dynamic obj)
        {
            dynamic old = this.map[(int)pos1.X, (int)pos1.Y];
            this.set(pos2, obj);
            this.set(old, null);
        }
    }

}
