using Simulation.Cores.MonteCarloSimulation;
using Simulation.Generators;
using Simulation.ValuesForGenerators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Simulation
{
    internal class SimulationTaskA : MonteCarloCore
    {
        DiscreteUniformGenerator genAB;
        DeterministicGenerator genBC;
        DiscreteEmpiricGenerator genCM;
        ValuesForGens valuesForGens;

        double timeRouteA;
        private double sumWaitTimeTaskA, avgWaitTimeTaskA;

        public double SumWaitTimeTaskA { get => sumWaitTimeTaskA; set => sumWaitTimeTaskA = value; }
        public double AvgWaitTimeTaskA { get => avgWaitTimeTaskA; set => avgWaitTimeTaskA = value; }


        public SimulationTaskA(ValuesForGens valuesForGens_)
        {
            valuesForGens = valuesForGens_;
        }

        public override void AfterReplication()
        {
            if (timeRouteA > 125)
            {
                SumWaitTimeTaskA += timeRouteA - 125;
            }
            AvgWaitTimeTaskA = SumWaitTimeTaskA / RepsDone;
        }

        public override void AfterSimulation()
        {
            AvgWaitTimeTaskA = SumWaitTimeTaskA / RepsDone;
        }

        public override void BeforeReplication()
        {
            timeRouteA = 0;
        }

        public override void BeforeSimulation()
        {
            SumWaitTimeTaskA = 0;
            AvgWaitTimeTaskA = 0;

            Random seedGen = new Random();

            genAB = new DiscreteUniformGenerator(valuesForGens.ArrDiscreteUniform[0][0], valuesForGens.ArrDiscreteUniform[0][1]);
            genBC = new DeterministicGenerator(valuesForGens.ArrDeterministic[0]);
            genCM = new DiscreteEmpiricGenerator(seedGen, valuesForGens.ArrDiscreteEmpiric[0]);
        }

        public override void OneReplication()
        {
            timeRouteA += genAB.GenerateValue();
            timeRouteA += genBC.GenerateValue();
            timeRouteA += genCM.GenerateValue();
        }
    }
}
