using Simulation.Cores.EventSimulation;
using Simulation.STK.Objects;
using Simulation.ValuesForGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.STK.Events
{
    internal class InspectionStartEvent : STKEvent
    {
        public InspectionStartEvent(double timeOfEvent_, EventSimulationCore core_) : base(timeOfEvent_, core_)
        {
            TimeOfEvent = timeOfEvent_;
            Core = core_;
            TempCore = (STKCore)core_;
        }

        public override void Execute()
        {
            TempCore.ActualTime = TimeOfEvent;

            
            if (Customer.ServingMechanic == null)
            {
                TempCore.AvgWFreeMechanics.ChangeInQueue(TimeOfEvent, TempCore.FreeMechanics.Count);
                Customer.ServingMechanic = TempCore.FreeMechanics.Dequeue();
            } 
            

            double pGen = TempCore.ProbabilityGenerator.NextDouble();
            double timeInInspection;
            if (pGen < TempCore.Probabilities[0])
            {
                timeInInspection = TempCore.PersonalCarGenerator.GenerateValue();
                TimeOfEvent += timeInInspection;
                Customer.ServingMechanic.TypeOfCar = "Personal";
            }
            else if (pGen < TempCore.Probabilities[1] + TempCore.Probabilities[0] && pGen >= TempCore.Probabilities[0])
            {
                timeInInspection = TempCore.VanGenerator.GenerateValue();
                TimeOfEvent += timeInInspection;
                Customer.ServingMechanic.TypeOfCar = "Van";
            }
            else
            {
                timeInInspection = TempCore.TruckGenerator.GenerateValue();
                TimeOfEvent += timeInInspection;
                Customer.ServingMechanic.TypeOfCar = "Truck";
            }

            TempCore.TimeInInspection.Sum += timeInInspection;
            TempCore.TimeInInspection.Count++;
            
            Customer.Position = "In inspection";
            InspectionEndEvent endInspection = new InspectionEndEvent(TimeOfEvent, TempCore);
            Customer.ServingMechanic.Job = "Inspecting";
            Customer.ServingMechanic.CustomerId = Customer.Id;
            endInspection.Customer = Customer;
            TempCore.AddEvent(endInspection);
        }
    }
}
