using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Generators
{
    internal class TriangularGenerator : Generator<double>
    {
        private double a, b, c;
        private Random generator;

        public TriangularGenerator(double a_, double b_, double c_, Random seedGenerator)
        {
            a = a_;
            b = b_;
            c = c_;
            generator = new Random(seedGenerator.Next());
        }
        public override double GenerateValue()
        {
            double u = generator.NextDouble();
            if (u < (c - a) / (b - a))
            {
                return a + Math.Sqrt(u * (b - a) * (c - a));
            }
            else
            {
                return b - Math.Sqrt((1 - u) * (b - a) * (b - c));
            }
        }
    }
}
