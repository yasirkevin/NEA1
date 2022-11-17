using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation1
{
    class Gene
    {
        public string code { private set; get }
        Gene(string code, SensoryCollection sensoryColl, InternalCollection internalColl)
        {
            this.code = code;

        }
    }
}
