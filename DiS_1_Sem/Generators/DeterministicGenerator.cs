using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Generators
{
    internal class DeterministicGenerator : Generator<int> 
    {
        private int value;
        public DeterministicGenerator(int value_)
        {
            value = value_;
        }

        public override int GenerateValue()
        {
            return value;
        }
    }
}
