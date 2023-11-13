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
    internal class ServiceEndEvent : STKEvent
    {
        public ServiceEndEvent(double timeOfEvent_, EventSimulationCore core_) : base(timeOfEvent_, core_)
        {
            TimeOfEvent = timeOfEvent_;
            Core = core_;
            TempCore = (STKCore)core_;
        }

        public override void Execute()
        {
            TempCore.ActualTime = TimeOfEvent;
            if(Customer.InspectionDone == true)
            {
                CustomerDepartureEvent customerDeparture = new CustomerDepartureEvent(TimeOfEvent, TempCore);
                customerDeparture.Customer = Customer;
                TempCore.AddEvent(customerDeparture);
            }
            else
            {
                Customer.CarHandedOver = true;
                if(Customer.InQueueForInspection == true && TempCore.NumberOfFreeMechanics == 0)
                {
                    TempCore.CustomersInspection.Enqueue(Customer);
                } 
                else
                {
                    if (Customer.InQueueForInspection == true)
                    {
                        TempCore.NumberOfCarsBeforeInspection--;
                        TempCore.NumberOfFreeMechanics--;
                    }
                    InspectionStartEvent startInspection = new InspectionStartEvent(TimeOfEvent, TempCore);
                    startInspection.Customer = Customer;
                    TempCore.AddEvent(startInspection);
                }
            }

            if(TempCore.CustomersPaying.Count > 0)
            {
                ServiceStartEvent startService = new ServiceStartEvent(TimeOfEvent, TempCore);
                startService.Customer = TempCore.CustomersPaying.Dequeue();
                startService.Customer.ServingClerk = Customer.ServingClerk;
                TempCore.AddEvent(startService);
            }
            else if(TempCore.CustomersCheckIn.Count > 0 &&
                        (TempCore.NumberOfFreeMechanics > 0 ||
                        TempCore.NumberOfCarsBeforeInspection < 5))
            {
                
                ServiceStartEvent startService = new ServiceStartEvent(TimeOfEvent, TempCore);
                TempCore.AvgWCustomersInQCheckIn.ChangeInQueue(TimeOfEvent, TempCore.CustomersCheckIn.Count);
                startService.Customer = TempCore.CustomersCheckIn.Dequeue();
                startService.Customer.ServingClerk = Customer.ServingClerk;
                if (TempCore.NumberOfFreeMechanics > 0)
                {
                    TempCore.NumberOfFreeMechanics--;
                }
                else
                {
                    startService.Customer.InQueueForInspection = true;
                    TempCore.NumberOfCarsBeforeInspection++;
                }
                TempCore.AddEvent(startService);
            }
            else
            {
                TempCore.NumberOfFreeClerks++;
                Customer.ServingClerk.Job = "Idle";
                Customer.ServingClerk.CustomerId = 0;
                TempCore.AvgWFreeClerks.ChangeInQueue(TimeOfEvent, TempCore.FreeClerks.Count);
                TempCore.FreeClerks.Enqueue(Customer.ServingClerk);
            }
        }
    }
}
