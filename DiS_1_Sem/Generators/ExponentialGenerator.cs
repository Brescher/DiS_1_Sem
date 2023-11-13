using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Generators
{
    internal class ExponentialGenerator : Generator<double>
    {
        private double mean;
        private Random generator;
        public ExponentialGenerator(Random seedGenerator_, double mean_) {
            this.generator = new Random(seedGenerator_.Next());
            this.mean = mean_;
        }
        public override double GenerateValue()
        {
            double lambda = (1/mean);
            return -1*(Math.Log(generator.NextDouble()))/lambda;
        }
    }
}
