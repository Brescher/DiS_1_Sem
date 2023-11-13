using Simulation.Cores.EventSimulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.NSStand
{
    internal class ServiceStartEventnss : NewspaperStandEvent
    {
        public ServiceStartEventnss(double timeOfEvent_, EventSimulationCore core_) : base(timeOfEvent_, core_)
        {
            TimeOfEvent = timeOfEvent_;
            //Core = core_;
            TempCore = (NewspaperStandCore)core_;
        }

        public override void Execute()
        {
            TempCore.ActualTime = TimeOfEvent;
            ServiceEndEventnss endService = new ServiceEndEventnss(TempCore.ActualTime + TempCore.getServiceTime(), TempCore);
            TempCore.AddEvent(endService);
        }
    }
}
