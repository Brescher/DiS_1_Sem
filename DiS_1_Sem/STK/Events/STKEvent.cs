using Simulation.Cores.EventSimulation;
using Simulation.NSStand;
using Simulation.STK.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.STK.Events
{
    internal abstract class STKEvent : Event
    {
        private STKCustomer customer;
        private STKCore tempCore;
        protected STKEvent(double timeOfEvent_, EventSimulationCore core_) : base(timeOfEvent_, core_)
        {
            TimeOfEvent = timeOfEvent_;
            Core = core_;
            TempCore = ( STKCore )core_;
        }

        protected STKCore TempCore { get => tempCore; set => tempCore = value; }
        public STKCustomer Customer { get => customer; set => customer = value; }
    }
}
