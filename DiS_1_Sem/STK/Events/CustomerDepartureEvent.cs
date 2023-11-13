using Simulation.Cores.EventSimulation;
using Simulation.STK.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.STK.Events
{
    internal class CustomerDepartureEvent : STKEvent
    {
        STKCustomer customer;
        public CustomerDepartureEvent(double timeOfEvent_, EventSimulationCore core_) : base(timeOfEvent_, core_)
        {
            TimeOfEvent = timeOfEvent_;
            Core = core_;
            TempCore = (STKCore)core_;
        }

        internal STKCustomer Customer { get => customer; set => customer = value; }

        public override void Execute()
        {
            TempCore.ActualTime = TimeOfEvent;
            Customer.DepartureTime = TimeOfEvent;
            //statistiky

            TempCore.AvgTimeInSystem.Sum += Customer.getTimeInSystem();
            TempCore.AvgTimeInSystem.Sumsq += Math.Pow(Customer.getTimeInSystem(), 2);
            TempCore.AvgTimeInSystem.Count++;
            TempCore.AvgWCustomersInSystem.ChangeInQueue(TimeOfEvent, TempCore.CustomersInSystem.Count);
            TempCore.CustomersInSystem.Remove(Customer.Id);
        }
    }
}
