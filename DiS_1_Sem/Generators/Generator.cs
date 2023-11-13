using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Generators
{
    internal abstract class Generator<T>
    {
        public Generator() { }

        public abstract T GenerateValue();
    }
}
