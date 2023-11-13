using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.ValuesForGenerators
{
    internal class ValuesForGens
    {
        int[][] arrDiscreteUniform;
        double[][] arrContinuousUniform;
        ValueForGen[][] arrDiscreteEmpiric;
        int[] arrDeterministic;

        public int[][] ArrDiscreteUniform { get => arrDiscreteUniform; set => arrDiscreteUniform = value; }
        public double[][] ArrContinuousUniform { get => arrContinuousUniform; set => arrContinuousUniform = value; }
        public int[] ArrDeterministic { get => arrDeterministic; set => arrDeterministic = value; }
        internal ValueForGen[][] ArrDiscreteEmpiric { get => arrDiscreteEmpiric; set => arrDiscreteEmpiric = value; }

        public ValuesForGens(int[][] arrDiscreteUniform, double[][] arrContinuousUniform, ValueForGen[][] arrDiscreteEmpiric, int[] arrDeterministic)
        {
            ArrDiscreteUniform = arrDiscreteUniform;
            ArrContinuousUniform = arrContinuousUniform;
            ArrDiscreteEmpiric = arrDiscreteEmpiric;
            ArrDeterministic = arrDeterministic;
        }

        public ValuesForGens() { }


    }
}
