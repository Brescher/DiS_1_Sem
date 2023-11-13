using Simulation.Cores.EventSimulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.NSStand
{
    internal class ServiceEndEventnss : NewspaperStandEvent
    {
        public ServiceEndEventnss(double timeOfEvent_, EventSimulationCore core_) : base(timeOfEvent_, core_)
        {
            TimeOfEvent = timeOfEvent_;
            //Core = core_;
            TempCore = (NewspaperStandCore)core_;
        }

        public override void Execute()
        {
            TempCore.ActualTime = TimeOfEvent;
            if (TempCore.Queue.Count != 0)
            {
                Customer customer = TempCore.Queue.Dequeue();

                TempCore.SumQueueWaitTime += TimeOfEvent - customer.StartWaitTime;
                TempCore.AvgWaitQueueTime = TempCore.SumQueueWaitTime / TempCore.NumberOfCustomers;

                ServiceStartEventnss start = new ServiceStartEventnss(TimeOfEvent, TempCore);
                TempCore.AddEvent(start);
            }
            else
            {
                TempCore.Works = false;
            }

        }
    }
}
