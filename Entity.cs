using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Implementation1
{
    class Entity
    {
        public Genome genome { private set; get; }
        public Vector2 position { private set; get; }

        public Vector2 lastPosition { private set; get; }


    }
}
