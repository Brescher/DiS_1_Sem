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
    internal class SimulationTaskB : MonteCarloCore
    {
        ContinuousUniformGenerator genDE;
        DiscreteEmpiricGenerator genEC;
        DiscreteEmpiricGenerator genCM;
        ValuesForGens valuesForGens;
        double timeRouteB, plotPoints;
        double[] plotX = new double[1000];
        double[] plotY = new double[1000];
        int indexPlot;

        private double probabilityTaskB, hits;

        public double ProbabilityTaskB { get => probabilityTaskB; set => probabilityTaskB = value; }
        public double[] PlotX { get => plotX; set => plotX = value; }
        public double[] PlotY { get => plotY; set => plotY = value; }
        public int IndexPlot { get => indexPlot; set => indexPlot = value; }


        public SimulationTaskB(ValuesForGens valuesForGens_)
        {
            valuesForGens = valuesForGens_;
        }

        public override void AfterReplication()
        {
            if (timeRouteB <= 320)
            {
                hits++;
            }
            probabilityTaskB = hits / RepsDone;
            if (RepsDone % plotPoints == 0 && replications >= 1000)
            {
                plotX[indexPlot] = RepsDone;
                plotY[indexPlot] = ProbabilityTaskB;
                indexPlot++;
            }
            else if (replications < 1000)
            {
                plotX[indexPlot] = RepsDone;
                plotY[indexPlot] = ProbabilityTaskB;
                indexPlot++;
            }
        }

        public override void AfterSimulation()
        {
            ProbabilityTaskB = hits / RepsDone;
        }

        public override void BeforeReplication()
        {
            timeRouteB = 0;
        }

        public override void BeforeSimulation()
        {
            plotPoints = replications / 1000;
            ProbabilityTaskB = 0;
            hits = 0;
            IndexPlot = 0;
            Random seedGen = new Random();

            genDE = new ContinuousUniformGenerator(valuesForGens.ArrContinuousUniform[0][0], valuesForGens.ArrContinuousUniform[0][1]);
            genEC = new DiscreteEmpiricGenerator(seedGen, valuesForGens.ArrDiscreteEmpiric[1]);
            genCM = new DiscreteEmpiricGenerator(seedGen, valuesForGens.ArrDiscreteEmpiric[0]);
        }

        public override void OneReplication()
        {
            timeRouteB += genDE.GenerateValue();
            timeRouteB += genEC.GenerateValue();
            timeRouteB += genCM.GenerateValue();
        }
    }
}
