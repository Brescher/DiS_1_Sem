using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Cores.MonteCarloSimulation
{
    internal abstract class MonteCarloCore : SimulationCore
    {
        //protected double replications;
        //private int repsDone;

        //protected int RepsDone { get => repsDone; set => repsDone = value; }

        //public async Task Simulate(double replications_, CancellationToken cancelToken)
        //{
        //    replications = replications_;
        //    RepsDone = 0;
        //    BeforeSimulation();
        //    for (int i = 0; i < replications; i++)
        //    {
        //        BeforeReplication();
        //        OneReplication();
        //        RepsDone++;
        //        AfterReplication();
        //        if (cancelToken.IsCancellationRequested)
        //        {
        //            break;
        //        }
        //    }
        //    AfterSimulation();
        //}

        //public abstract void OneReplication();
        //public override abstract void BeforeSimulation();
        //public override abstract void AfterSimulation();
        //public override abstract void BeforeReplication();
        //public override abstract void AfterReplication();
    }
}
