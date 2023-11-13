using Simulation.Cores.EventSimulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.NSStand
{
    internal class CustomerArrivalEventnss : NewspaperStandEvent
    {
        public CustomerArrivalEventnss(double timeOfEvent_, EventSimulationCore core_) : base(timeOfEvent_, core_)
        {
            TimeOfEvent = timeOfEvent_;
            //Core = core_;
            TempCore = (NewspaperStandCore)core_;
        }

        public override void Execute()
        {
            TempCore.ActualTime = TimeOfEvent;
            if (!TempCore.Works)
            {
                ServiceStartEventnss startService = new ServiceStartEventnss(TimeOfEvent, TempCore);
                TempCore.AddEvent(startService);
                TempCore.Works = true;
            }
            else
            {
                Customer = new Customer(TimeOfEvent);
                TempCore.Queue.Enqueue(Customer);
            }
            TempCore.countQueueSize();
            TempCore.NumberOfCustomers++;
            TimeOfEvent += TempCore.getArrivalTime();
            TempCore.AddEvent(this);
        }
    }
}
