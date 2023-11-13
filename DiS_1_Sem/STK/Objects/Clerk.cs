using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.STK.Objects
{
    internal class Clerk
    {
        string job;
        int id, customerId;

        public Clerk(int id_)
        {
            Job = "Idle";
            Id = id_;
        }

        public string Job { get => job; set => job = value; }
        public int Id { get => id; set => id = value; }
        public int CustomerId { get => customerId; set => customerId = value; }
    }
}
