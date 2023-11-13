using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.ValuesForGenerators
{

    internal class ValueForGen
    {
        private int tMin, tMax;

        private double p;

        public int TMin { get => tMin; set => tMin = value; }
        public int TMax { get => tMax; set => tMax = value; }
        public double P { get => p; set => p = value; }

        public ValueForGen(int Tmin_, int Tmax_, double p_)
        {
            TMin = Tmin_;
            TMax = Tmax_;
            P = p_;
        }


    }
}
