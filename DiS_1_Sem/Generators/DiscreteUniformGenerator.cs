using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Generators
{
    internal class DiscreteUniformGenerator : Generator<int>
    {
        int tMin, tMax;
        private Random generator;
        public DiscreteUniformGenerator(int tMin_, int tMax_)
        {
            generator = new Random();
            tMin = tMin_;
            tMax = tMax_;
        }

        public override int GenerateValue()
        {
            int value = generator.Next(tMin, tMax + 1);
            return value;
        }
    }
}
