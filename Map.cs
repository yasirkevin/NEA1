using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
namespace Implementation1
{
    public class Map
    {
        public dynamic[,] map { private set; get; } // 2D array which can have null values or entities or obstacles, etc
        public int sizeX { private set; get; } 
        public int sizeY { private set; get; }

        public Map(int sizeX, int sizeY)
        {
            this.map    = new dynamic[sizeX, sizeY];
            this.sizeX  = sizeX;
            this.sizeY  = sizeY;
        } 

        /// <summary>
        /// Set the value of a position in the map to a specified object
        /// </summary>
        public void set(int posX, int posY, dynamic obj)
        {
            if (posX > this.map.GetLength(0) || posY > this.map.GetLength(1)) // The position to set the object to cannot be above the bounds of the map
            {
                throw new ArgumentException();
            }

            map[posX, posY] = obj;
        }

        public void set(Vector2 pos, dynamic obj) { this.set((int)pos.X, (int)pos.Y, obj); }

        /// <summary>
        /// Change the position of an existing object in the map
        /// </summary>
        public void change(Vector2 pos1, Vector2 pos2, dynamic obj)
        {
            dynamic old = this.map[(int)pos1.X, (int)pos1.Y]; // Store old position of the object
            this.set(pos2, obj); // Set the new position of the object
            this.set(old, null); // Change the value of the old position to null
        }
    }

}
