using Simulation.Cores.EventSimulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.STK
{
    internal interface ISimDelegate
    {
        void Refresh(EventSimulationCore core);
    }
}
