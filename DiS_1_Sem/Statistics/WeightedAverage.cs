using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Statistics
{
    internal class WeightedAverage
    {
        double sum, count, avg, lastChange;

        public WeightedAverage()
        {
            sum = 0;
            count = 0;
            avg = 0;
            lastChange = 0;
        }

        public double Sum { get => sum; set => sum = value; }
        public double Count { get => count; set => count = value; }
        public double Avg { get => avg; set => avg = value; }
        public double LastChange { get => lastChange; set => lastChange = value; }

        public void ChangeInQueue(double actualTime_, double queueSize)
        {
            double time = actualTime_ - lastChange;
            sum += time;
            Count += time * queueSize;
            Avg = count / sum;
            lastChange = actualTime_;
        }

    }
}
