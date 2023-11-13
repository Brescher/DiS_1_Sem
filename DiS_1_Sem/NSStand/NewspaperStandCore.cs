using Simulation.Cores.EventSimulation;
using Simulation.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.NSStand
{
    internal class NewspaperStandCore : EventSimulationCore
    {
        private ExponentialGenerator arrivalGen;
        private ExponentialGenerator serviceGen;
        private Queue<Customer> queue = new Queue<Customer>();
        private double timeOfLastChangeInQueue, sumQueueWaitTime, numberOfCustomers, avgWaitQueueTime, countOfQueueEvents, avgQueueSize;
        private bool works;
        public NewspaperStandCore(PriorityQueue<Event, double> timeline_, double actualTime_) : base(timeline_, actualTime_)
        {
            timeline = timeline_;
            ActualTime = actualTime_;
            Random seedGen = new Random();
            ArrivalGen = new ExponentialGenerator(seedGen, 5);
            ServiceGen = new ExponentialGenerator(seedGen, 4);
            Works = false;
            NumberOfCustomers = 0;
            SumQueueWaitTime = 0;
            TimeOfLastChangeInQueue = 0;
        }

        public double TimeOfLastChangeInQueue { get => timeOfLastChangeInQueue; set => timeOfLastChangeInQueue = value; }
        public bool Works { get => works; set => works = value; }
        public ExponentialGenerator ArrivalGen { get => arrivalGen; set => arrivalGen = value; }
        public ExponentialGenerator ServiceGen { get => serviceGen; set => serviceGen = value; }
        public Queue<Customer> Queue { get => queue; set => queue = value; }
        public double SumQueueWaitTime { get => sumQueueWaitTime; set => sumQueueWaitTime = value; }
        public double NumberOfCustomers { get => numberOfCustomers; set => numberOfCustomers = value; }
        public double AvgWaitQueueTime { get => avgWaitQueueTime; set => avgWaitQueueTime = value; }
        public double CountOfEventQueue { get => countOfQueueEvents; set => countOfQueueEvents = value; }
        public double AvgQueueSize { get => avgQueueSize; set => avgQueueSize = value; }

        public double getArrivalTime()
        {
            return arrivalGen.GenerateValue();
        }

        public double getServiceTime()
        {
            return serviceGen.GenerateValue();
        }

        public void countQueueSize()
        {
            double time = ActualTime - TimeOfLastChangeInQueue;
            CountOfEventQueue += time * Queue.Count;
            TimeOfLastChangeInQueue = ActualTime;
            AvgQueueSize = CountOfEventQueue / ActualTime;
        }

        public override void AfterReplication()
        {
            throw new NotImplementedException();
        }

        public override void AfterSimulation()
        {
            throw new NotImplementedException();
        }

        public override void BeforeReplication()
        {
            throw new NotImplementedException();
        }

        public override void BeforeSimulation()
        {
            throw new NotImplementedException();
        }

        
    }
}
