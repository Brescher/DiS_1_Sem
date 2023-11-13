using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Generators
{
    internal class ContinuousUniformGenerator : Generator<double>
    {
        private double tMin, tMax;
        private Random generator;

        public ContinuousUniformGenerator(double tMin_, double tMax_)
        {
            tMin = tMin_;
            tMax = tMax_;
            generator = new Random();
        }

        public override double GenerateValue()
        {
            double value = generator.NextDouble() * (tMax - tMin) + tMin;
            return value;
        }
    }
}
