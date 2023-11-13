using Simulation.STK;
using Simulation.STK.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Cores.EventSimulation
{
    internal class SystemEvent : STKEvent
    {

        public SystemEvent(double timeOfEvent_, EventSimulationCore core_) : base(timeOfEvent_, core_)
        {
            TimeOfEvent = timeOfEvent_;
            Core = core_;
            TempCore = (STKCore)core_;
        }

        public override void Execute()
        {
            Thread.Sleep(TempCore.ServiceEventSleepTime);
            SystemEvent systemE = new SystemEvent(TimeOfEvent + TempCore.IntervalOfSystemEvents, TempCore);
            TempCore.AddEvent(systemE);
        }
    }
}
