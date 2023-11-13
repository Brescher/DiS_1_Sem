using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.STK.Objects
{
    
    internal class STKCustomer
    {
        double queueEntranceStartWaitTime, queueEntranceEndWaitTime, queueDepartureStartWaitTime, queueDepartureEndWaitTime, arrivalTime, departureTime;
        bool carHandedOver, inspectionDone, inQueueForInspection;
        Clerk servingClerk;
        Mechanic servingMechanic;
        int id;
        String position;

        public double QueueEntranceStartWaitTime { get => queueEntranceStartWaitTime; set => queueEntranceStartWaitTime = value; }
        public double QueueEntranceEndWaitTime { get => queueEntranceEndWaitTime; set => queueEntranceEndWaitTime = value; }
        public double QueueDepartureStartWaitTime { get => queueDepartureStartWaitTime; set => queueDepartureStartWaitTime = value; }
        public double QueueDepartureEndWaitTime { get => queueDepartureEndWaitTime; set => queueDepartureEndWaitTime = value; }
        public double ArrivalTime { get => arrivalTime; set => arrivalTime = value; }
        public double DepartureTime { get => departureTime; set => departureTime = value; }
        public bool CarHandedOver { get => carHandedOver; set => carHandedOver = value; }
        public bool InspectionDone { get => inspectionDone; set => inspectionDone = value; }
        public bool InQueueForInspection { get => inQueueForInspection; set => inQueueForInspection = value; }
        internal Clerk ServingClerk { get => servingClerk; set => servingClerk = value; }
        internal Mechanic ServingMechanic { get => servingMechanic; set => servingMechanic = value; }
        public int Id { get => id; set => id = value; }
        public string Position { get => position; set => position = value; }

        public STKCustomer(double arrivalTime)
        {
            this.ArrivalTime = arrivalTime;
            CarHandedOver = false;
            InspectionDone = false;
            InQueueForInspection = false;
        }

       

        public double getTimeInSystem()
        {
            return DepartureTime - ArrivalTime;
        }

        public double getTimeInCheckingQueue()
        {
            return queueEntranceEndWaitTime - queueEntranceStartWaitTime;
        }

        public double getTimeInPayingQueue()
        {
            return queueDepartureEndWaitTime - queueDepartureStartWaitTime;
        }
    }
}
