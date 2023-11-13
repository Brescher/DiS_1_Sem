using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.ValuesForGenerators;

namespace Simulation.Generators
{
    internal class DiscreteEmpiricGenerator : Generator<int>
    {
        private ValueForGen[] valuesForGens; 
        private Random[] generators;
        private Random probability;
        private Random seedGenerator;
        public DiscreteEmpiricGenerator(Random seedGenerator_, ValueForGen[] valuesForGen_)
        {
            seedGenerator = seedGenerator_;
            valuesForGens = valuesForGen_;
            probability = new Random(seedGenerator.Next());
            generators = new Random[valuesForGens.Length];
            for (int i = 0; i < valuesForGens.Length; i++)
            {
                generators[i] = new Random(seedGenerator.Next());
            }
        }

        public override int GenerateValue()
        {
            double pGen = probability.NextDouble();

            int i = 0;
            double p = 0;
            for (; i < valuesForGens.Length; i++)
            {
                p += valuesForGens[i].P;
                if (pGen < p)
                {
                    break;
                }
            }
            return generators[i].Next(valuesForGens[i].TMin, valuesForGens[i].TMax + 1);
        }
    }
}
