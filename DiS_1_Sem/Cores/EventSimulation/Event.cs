using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Cores.EventSimulation
{
    internal abstract class Event
    {
        protected double timeOfEvent;
        private EventSimulationCore core;

        public double TimeOfEvent { get => timeOfEvent; set => timeOfEvent = value; }
        protected EventSimulationCore Core { get => core; set => core = value; }

        protected Event(double timeOfEvent_, EventSimulationCore core_)
        {
            TimeOfEvent = timeOfEvent_;
            Core = core_;
        }

        public abstract void Execute();
    }
}
