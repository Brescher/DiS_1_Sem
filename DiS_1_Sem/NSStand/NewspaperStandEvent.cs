using Simulation.Cores.EventSimulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.NSStand
{
    internal abstract class NewspaperStandEvent : Event
    {
        private Customer customer;
        private NewspaperStandCore tempCore;
        protected NewspaperStandEvent(double timeOfEvent_, EventSimulationCore core_) : base(timeOfEvent_, core_)
        {
            TimeOfEvent = timeOfEvent_;
            //Core = core_;
            TempCore = (NewspaperStandCore)core_;
        }

        protected Customer Customer { get => customer; set => customer = value; }
        protected NewspaperStandCore TempCore { get => tempCore; set => tempCore = value; }
    }
}
