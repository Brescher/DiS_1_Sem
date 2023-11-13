using Simulation.Cores.EventSimulation;
using Simulation.STK.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.STK.Events
{
    internal class InspectionEndEvent : STKEvent
    {
        public InspectionEndEvent(double timeOfEvent_, EventSimulationCore core_) : base(timeOfEvent_, core_)
        {
            TimeOfEvent = timeOfEvent_;
            Core = core_;
            TempCore = (STKCore)core_;
        }

        public override void Execute()
        {
            TempCore.ActualTime = TimeOfEvent;

            Customer.InspectionDone = true;
            Customer.QueueDepartureStartWaitTime = TimeOfEvent;
            TempCore.NumberOfCarsChecked++;
            if(TempCore.NumberOfFreeClerks > 0)
            {
                TempCore.NumberOfFreeClerks--;
                TempCore.AvgWFreeClerks.ChangeInQueue(TimeOfEvent, TempCore.FreeClerks.Count);
                Customer.ServingClerk = TempCore.FreeClerks.Dequeue();
                ServiceStartEvent startService = new ServiceStartEvent(TimeOfEvent, TempCore);
                startService.Customer = Customer;
                TempCore.AddEvent(startService);
            }
            else
            {
                Customer.Position = "In paying queue";
                TempCore.CustomersPaying.Enqueue(Customer);
            }

            if(TempCore.CustomersInspection.Count > 0) 
            {
                TempCore.NumberOfCarsBeforeInspection--;
                InspectionStartEvent inspectionStart = new InspectionStartEvent(TimeOfEvent, TempCore);
                inspectionStart.Customer = TempCore.CustomersInspection.Dequeue();
                inspectionStart.Customer.ServingMechanic = Customer.ServingMechanic;
                TempCore.AddEvent(inspectionStart);
            }
            else
            {
                TempCore.NumberOfFreeMechanics++;
                Customer.ServingMechanic.Job = "Idle";
                Customer.ServingMechanic.TypeOfCar = "-";
                Customer.ServingMechanic.CustomerId = 0;
                TempCore.AvgWFreeMechanics.ChangeInQueue(TimeOfEvent, TempCore.FreeMechanics.Count);
                TempCore.FreeMechanics.Enqueue(Customer.ServingMechanic);
            }

            if (TempCore.NumberOfFreeClerks > 0 &&
                TempCore.CustomersCheckIn.Count > 0 &&
                (TempCore.NumberOfFreeMechanics > 0 ||
                TempCore.NumberOfCarsBeforeInspection < 5))
            {
                ServiceStartEvent serviceEvent = new ServiceStartEvent(TimeOfEvent, TempCore);
                TempCore.AvgWFreeClerks.ChangeInQueue(TimeOfEvent, TempCore.FreeClerks.Count);
                TempCore.AvgWCustomersInQCheckIn.ChangeInQueue(TimeOfEvent, TempCore.CustomersCheckIn.Count);
                serviceEvent.Customer = TempCore.CustomersCheckIn.Dequeue();
                serviceEvent.Customer.ServingClerk = TempCore.FreeClerks.Dequeue();
                TempCore.NumberOfFreeClerks--;
                if (TempCore.NumberOfFreeMechanics > 0)
                {
                    TempCore.NumberOfFreeMechanics--;
                }
                else
                {
                    serviceEvent.Customer.InQueueForInspection = true;
                    TempCore.NumberOfCarsBeforeInspection++;
                }

                TempCore.AddEvent(serviceEvent);
            }
        }
    }
}
