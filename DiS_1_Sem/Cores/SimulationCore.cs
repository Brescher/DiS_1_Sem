using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Cores
{
    internal abstract class SimulationCore
    {
        protected double replications;
        private int repsDone;
        private CancellationToken cancelToken;

        public int RepsDone { get => repsDone; set => repsDone = value; }
        public CancellationToken CancelToken { get => cancelToken; set => cancelToken = value; }

        public async Task Simulate(double replications_)
        {
            replications = replications_;
            RepsDone = 0;
            BeforeSimulation();
            for (int i = 0; i < replications; i++)
            {
                BeforeReplication();
                OneReplication();
                RepsDone++;
                AfterReplication();
                if (cancelToken.IsCancellationRequested)
                {
                    break;
                }
            }
            AfterSimulation();
        }

        public abstract void OneReplication();
        public abstract void BeforeSimulation();
        public abstract void AfterSimulation();
        public abstract void BeforeReplication();
        public abstract void AfterReplication();
    }
}
