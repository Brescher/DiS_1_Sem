using ScottPlot.SnapLogic;
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
    internal class CustomerArrivalEvent : STKEvent
    {
        public CustomerArrivalEvent(double timeOfEvent_, EventSimulationCore core_) : base(timeOfEvent_, core_)
        {
            TimeOfEvent = timeOfEvent_;
            Core = core_;
            TempCore = (STKCore)core_;
        }

        public override void Execute()
        {
            TempCore.ActualTime = TimeOfEvent;
            Customer = new STKCustomer(TimeOfEvent);
            Customer.QueueEntranceStartWaitTime = TimeOfEvent;
            TempCore.NumberOfCustomers++;
            Customer.Id = TempCore.NumberOfCustomers;
            TempCore.AvgWCustomersInSystem.ChangeInQueue(TimeOfEvent, TempCore.CustomersInSystem.Count);
            TempCore.CustomersInSystem.Add(Customer.Id, Customer);

            if (TempCore.NumberOfFreeClerks > 0 &&
               TempCore.CustomersCheckIn.Count == 0 &&
               (TempCore.NumberOfFreeMechanics > 0 ||
                TempCore.NumberOfCarsBeforeInspection < 5))
            {
                if(TempCore.NumberOfFreeMechanics > 0)
                {
                    TempCore.NumberOfFreeMechanics--;
                } else
                {
                    TempCore.NumberOfCarsBeforeInspection++;
                    Customer.InQueueForInspection = true;
                }
                TempCore.NumberOfFreeClerks--;
                TempCore.AvgWFreeClerks.ChangeInQueue(TimeOfEvent, TempCore.FreeClerks.Count);
                Customer.ServingClerk = TempCore.FreeClerks.Dequeue();
                ServiceStartEvent startService = new ServiceStartEvent(TimeOfEvent, TempCore);
                startService.Customer = Customer;
                TempCore.AddEvent(startService);
            }
            else
            {
                TempCore.AvgWCustomersInQCheckIn.ChangeInQueue(TimeOfEvent, TempCore.CustomersCheckIn.Count);
                Customer.Position = "In check in queue";
                TempCore.CustomersCheckIn.Enqueue(Customer);
            }

            TimeOfEvent += TempCore.CustomerGenerator.GenerateValue();
            if (TimeOfEvent < TempCore.MaxTime - 75)
            {
                TempCore.AddEvent(this);
            }
        }
    }
}
