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
    internal class ServiceStartEvent : STKEvent
    {
        public ServiceStartEvent(double timeOfEvent_, EventSimulationCore core_) : base(timeOfEvent_, core_)
        {
            TimeOfEvent = timeOfEvent_;
            Core = core_;
            TempCore = (STKCore)core_;
        }

        public override void Execute()
        {
            TempCore.ActualTime = TimeOfEvent;
            if (Customer.InspectionDone == false && Customer.CarHandedOver == false)
            {
                Customer.ServingClerk.CustomerId = Customer.Id;
                Customer.Position = "Checking in";
                Customer.ServingClerk.Job = "Checking in";
                Customer.QueueEntranceEndWaitTime = TimeOfEvent;
                TempCore.AvgTimeInQCheckIn.Sum += Customer.getTimeInCheckingQueue();
                TempCore.AvgTimeInQCheckIn.Sumsq += Math.Pow(Customer.getTimeInCheckingQueue(),2);
                TempCore.AvgTimeInQCheckIn.Count++;

                double genTime = TempCore.CheckingInGenerator.GenerateValue();
                TempCore.TimeInCheckIn.Sum += genTime;
                TempCore.TimeInCheckIn.Count++;
                ServiceEndEvent endService = new ServiceEndEvent(TempCore.ActualTime + genTime, TempCore);
                endService.Customer = Customer;
                TempCore.AddEvent(endService);
            }
            else if (Customer.InspectionDone == true && Customer.CarHandedOver == true)
            {
                Customer.ServingClerk.CustomerId = Customer.Id;
                Customer.Position = "Paying";
                Customer.ServingClerk.Job = "Processing payment";
                Customer.QueueDepartureEndWaitTime = TimeOfEvent;
                TempCore.AvgTimeInQPayment.Sum += Customer.getTimeInPayingQueue();
                TempCore.AvgTimeInQPayment.Sumsq += Math.Pow(Customer.getTimeInPayingQueue(),2);
                TempCore.AvgTimeInQPayment.Count++;
                ServiceEndEvent endService = new ServiceEndEvent(TimeOfEvent + TempCore.PayingTimeGenerator.GenerateValue(), TempCore);
                endService.Customer = Customer;
                TempCore.AddEvent(endService);
            }
        }
    }
}
