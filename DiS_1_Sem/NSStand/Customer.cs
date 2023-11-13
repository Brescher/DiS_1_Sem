using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.NSStand
{
    internal class Customer
    {
        private double startWaitTime;
        public double StartWaitTime { get => startWaitTime; set => startWaitTime = value; }
        public Customer(double startWaitTime_)
        {
            StartWaitTime = startWaitTime_;
        }


    }
}
