using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.STK.Objects
{
    internal class Mechanic
    {
        string job, typeOfCar;
        int id, customerId;

        public Mechanic(int id_)
        {
            Job = "Idle";
            Id = id_;
            TypeOfCar = "-";
        }

        public string Job { get => job; set => job = value; }
        public int Id { get => id; set => id = value; }
        public string TypeOfCar { get => typeOfCar; set => typeOfCar = value; }
        public int CustomerId { get => customerId; set => customerId = value; }
    }
}
