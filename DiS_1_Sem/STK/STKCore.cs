using Simulation.Cores.EventSimulation;
using Simulation.Generators;
using Simulation.Statistics;
using Simulation.STK.Events;
using Simulation.STK.Objects;
using Simulation.ValuesForGenerators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.STK
{
    internal class STKCore : EventSimulationCore
    {
        #region
        private ExponentialGenerator customerGenerator;
        private TriangularGenerator checkingInGenerator;
        private ContinuousUniformGenerator payingTimeGenerator;
        private DiscreteUniformGenerator personalCarGenerator;
        private DiscreteEmpiricGenerator vanGenerator;
        private DiscreteEmpiricGenerator truckGenerator;
        private Random probabilityGenerator, seedGenerator;

        private double[] probabilities = new double[3];
        private ValuesForGens values;

        int numberOfClerks, numberOfFreeClerks, numberOfMechanics, numberOfFreeMechanics, numberOfCustomers, 
            numberOfCarsChecked, numberOfCarsBeforeInspection;

        Dictionary<int, STKCustomer> customersInSystem = new Dictionary<int, STKCustomer>();
        List<Clerk> clerks = new List<Clerk>();
        List<Mechanic> mechanics = new List<Mechanic>();

        Queue<STKCustomer> customersCheckIn = new Queue<STKCustomer>();
        Queue<STKCustomer> customersPaying = new Queue<STKCustomer>();
        Queue<STKCustomer> customersInspection = new Queue<STKCustomer>();
        Queue<Clerk> freeClerks = new Queue<Clerk>();
        Queue<Mechanic> freeMechanics = new Queue<Mechanic>();

        Average avgTimeInSystem = new Average();
        Average avgTimeInQCheckIn = new Average();
        Average avgTimeInQPayment = new Average();
        Average avgCustomersAtTheEnd = new Average();
        Average avgCustomers = new Average();
        Average avgCustomersInSystem = new Average();
        Average avgFreeClerks = new Average();
        Average avgFreeMechanics = new Average();
        Average avgCustomersInQCheckIn = new Average();  
        Average timeInInspection = new Average();
        Average timeInCheckIn = new Average();

        WeightedAverage avgWFreeClerks = new WeightedAverage();
        WeightedAverage avgWFreeMechanics = new WeightedAverage();
        WeightedAverage avgWCustomersInSystem = new WeightedAverage();
        WeightedAverage avgWCustomersInQCheckIn = new WeightedAverage();
        #endregion
        public STKCore(PriorityQueue<Event, double> timeline_, double actualTime_) : base(timeline_, actualTime_)
        {
            timeline = timeline_;
            ActualTime = actualTime_;
            Pause = false;
        }
        #region 
        public Random ProbabilityGenerator { get => probabilityGenerator; set => probabilityGenerator = value; }
        public Random SeedGenerator { get => seedGenerator; set => seedGenerator = value; }
        public int NumberOfClerks { get => numberOfClerks; set => numberOfClerks = value; }
        public int NumberOfMechanics { get => numberOfMechanics; set => numberOfMechanics = value; }
        public int NumberOfCustomers { get => numberOfCustomers; set => numberOfCustomers = value; }
        public int NumberOfCarsChecked { get => numberOfCarsChecked; set => numberOfCarsChecked = value; }
        public int NumberOfFreeClerks { get => numberOfFreeClerks; set => numberOfFreeClerks = value; }
        public int NumberOfFreeMechanics { get => numberOfFreeMechanics; set => numberOfFreeMechanics = value; }
        public int NumberOfCarsBeforeInspection { get => numberOfCarsBeforeInspection; set => numberOfCarsBeforeInspection = value; }
        public double[] Probabilities { get => probabilities; set => probabilities = value; }
        internal Queue<STKCustomer> CustomersCheckIn { get => customersCheckIn; set => customersCheckIn = value; }
        internal Queue<STKCustomer> CustomersPaying { get => customersPaying; set => customersPaying = value; }
        internal Queue<STKCustomer> CustomersInspection { get => customersInspection; set => customersInspection = value; }
        internal ExponentialGenerator CustomerGenerator { get => customerGenerator; set => customerGenerator = value; }
        internal TriangularGenerator CheckingInGenerator { get => checkingInGenerator; set => checkingInGenerator = value; }
        internal ContinuousUniformGenerator PayingTimeGenerator { get => payingTimeGenerator; set => payingTimeGenerator = value; }
        internal DiscreteUniformGenerator PersonalCarGenerator { get => personalCarGenerator; set => personalCarGenerator = value; }
        internal DiscreteEmpiricGenerator VanGenerator { get => vanGenerator; set => vanGenerator = value; }
        internal DiscreteEmpiricGenerator TruckGenerator { get => truckGenerator; set => truckGenerator = value; }
        internal List<Clerk> Clerks { get => clerks; set => clerks = value; }
        internal List<Mechanic> Mechanics { get => mechanics; set => mechanics = value; }
        internal Queue<Clerk> FreeClerks { get => freeClerks; set => freeClerks = value; }
        internal Queue<Mechanic> FreeMechanics { get => freeMechanics; set => freeMechanics = value; }
        internal Dictionary<int, STKCustomer> CustomersInSystem { get => customersInSystem; set => customersInSystem = value; }
        internal Average AvgTimeInSystem { get => avgTimeInSystem; set => avgTimeInSystem = value; }
        internal Average AvgTimeInQCheckIn { get => avgTimeInQCheckIn; set => avgTimeInQCheckIn = value; }
        internal Average AvgTimeInQPayment { get => avgTimeInQPayment; set => avgTimeInQPayment = value; }
        internal Average AvgCustomersAtTheEnd { get => avgCustomersAtTheEnd; set => avgCustomersAtTheEnd = value; }
        internal Average AvgCustomers { get => avgCustomers; set => avgCustomers = value; }
        internal Average AvgCustomersInSystem { get => avgCustomersInSystem; set => avgCustomersInSystem = value; }
        internal WeightedAverage AvgWFreeClerks { get => avgWFreeClerks; set => avgWFreeClerks = value; }
        internal WeightedAverage AvgWFreeMechanics { get => avgWFreeMechanics; set => avgWFreeMechanics = value; }
        internal WeightedAverage AvgWCustomersInSystem { get => avgWCustomersInSystem; set => avgWCustomersInSystem = value; }
        internal Average AvgFreeClerks { get => avgFreeClerks; set => avgFreeClerks = value; }
        internal Average AvgFreeMechanics { get => avgFreeMechanics; set => avgFreeMechanics = value; }
        internal Average AvgCustomersInQCheckIn { get => avgCustomersInQCheckIn; set => avgCustomersInQCheckIn = value; }
        internal WeightedAverage AvgWCustomersInQCheckIn { get => avgWCustomersInQCheckIn; set => avgWCustomersInQCheckIn = value; }
        internal Average TimeInInspection { get => timeInInspection; set => timeInInspection = value; }
        internal Average TimeInCheckIn { get => timeInCheckIn; set => timeInCheckIn = value; }

        #endregion
        public override void AfterReplication()
        {

            CountStatistic();

            if (TurboMode == true)
            {
                if(RepsDone % 10000 == 0)
                {
                    CountAverages();
                    RefreshGUI();
                }
            } else
            {
                CountAverages();
                RefreshGUI();
            }


            ZeroStat();


            ActualTime = 0;
            timeline.Clear();
            customersCheckIn.Clear();
            customersPaying.Clear();
            customersInspection.Clear();
            FreeClerks.Clear();
            FreeMechanics.Clear();
            CustomersInSystem.Clear();
        }

        public override void AfterSimulation()
        {
            //RefreshGUI();
        }

        public override void BeforeReplication()
        {
            CustomerArrivalEvent start = new CustomerArrivalEvent(0, this);
            AddEvent(start);

            NumberOfFreeClerks = NumberOfClerks;
            NumberOfFreeMechanics = NumberOfMechanics;
            NumberOfCarsBeforeInspection = 0;
            NumberOfCustomers = 0;
            NumberOfCarsChecked = 0;
            NumberOfCarsBeforeInspection = 0;

            for (int i = 0; i < NumberOfClerks; i++)
            {
                Clerks[i].Job = "Idle";
                Clerks[i].CustomerId = 0;
                FreeClerks.Enqueue(Clerks[i]);
            }
            for (int i = 0; i < NumberOfMechanics; i++)
            {
                Mechanics[i].Job = "Idle";
                Mechanics[i].TypeOfCar = "-";
                Mechanics[i].CustomerId = 0;
                FreeMechanics.Enqueue(Mechanics[i]);
            }
        }

        public override void BeforeSimulation()
        {
            InitializeGenerators();
            for(int i = 1; i <= NumberOfClerks; i++)
            {
                Clerks.Add(new Clerk(i));
            }
            for (int i = 1; i <= NumberOfMechanics; i++)
            {
                Mechanics.Add(new Mechanic(i));
            }
        }

        private void CountStatistic()
        {
            AvgWFreeClerks.ChangeInQueue(MaxTime, FreeClerks.Count);
            AvgWFreeMechanics.ChangeInQueue(MaxTime, FreeMechanics.Count);
            AvgWCustomersInSystem.ChangeInQueue(MaxTime, CustomersInSystem.Count);
            AvgWCustomersInQCheckIn.ChangeInQueue(MaxTime, CustomersCheckIn.Count);

            AvgCustomersAtTheEnd.Sum += CustomersInSystem.Count();
            AvgCustomersAtTheEnd.Sumsq += Math.Pow(CustomersInSystem.Count(),2);
            AvgCustomersAtTheEnd.Count++;

            AvgCustomers.Sum += NumberOfCustomers;
            AvgCustomers.Sumsq += Math.Pow(NumberOfCustomers, 2);
            AvgCustomers.Count++;


            AvgCustomersInSystem.Sum += AvgWCustomersInSystem.Avg;
            AvgCustomersInSystem.Sumsq += Math.Pow(AvgWCustomersInSystem.Avg, 2);
            AvgCustomersInSystem.Count++;

            AvgFreeClerks.Sum += AvgWFreeClerks.Avg;
            AvgFreeClerks.Sumsq += Math.Pow(AvgWFreeClerks.Avg, 2);
            AvgFreeClerks.Count++;

            AvgFreeMechanics.Sum += AvgWFreeMechanics.Avg;
            AvgFreeMechanics.Sumsq += Math.Pow(AvgWFreeMechanics.Avg, 2);
            AvgFreeMechanics.Count++;

            AvgCustomersInQCheckIn.Sum += AvgWCustomersInQCheckIn.Avg;
            AvgCustomersInQCheckIn.Sumsq += Math.Pow(AvgWCustomersInQCheckIn.Avg, 2);
            AvgCustomersInQCheckIn.Count++;
        }

        public void CountAverages()
        {
            AvgCustomersAtTheEnd.CountAverage();
            AvgTimeInSystem.CountAverage();
            AvgTimeInQCheckIn.CountAverage();
            AvgTimeInQPayment.CountAverage();
            AvgCustomers.CountAverage();
            AvgCustomersInSystem.CountAverage();
            AvgFreeClerks.CountAverage();
            AvgFreeMechanics.CountAverage();
            AvgCustomersInQCheckIn.CountAverage();
            TimeInInspection.CountAverage();
            TimeInCheckIn.CountAverage();
        }

        private void ZeroStat()
        {
            

            AvgWCustomersInSystem.Count = 0;
            AvgWCustomersInSystem.Sum = 0;
            AvgWCustomersInSystem.Avg = 0;
            AvgWCustomersInSystem.LastChange = 0;

            AvgWFreeClerks.Count = 0;
            AvgWFreeClerks.Sum = 0;
            AvgWFreeClerks.Avg = 0;
            AvgWFreeClerks.LastChange = 0;

            AvgWFreeMechanics.Count = 0;
            AvgWFreeMechanics.Sum = 0;
            AvgWFreeMechanics.Avg = 0;
            AvgWFreeMechanics.LastChange = 0;

            AvgWCustomersInQCheckIn.Count = 0;
            AvgWCustomersInQCheckIn.Sum = 0;
            AvgWCustomersInQCheckIn.Avg = 0;
            AvgWCustomersInQCheckIn.LastChange = 0;
        }

        private void InitializeGenerators()
        {
            Probabilities[0] = 0.65;
            Probabilities[1] = 0.21;
            Probabilities[2] = 0.14;


            int[] personal = new int[2];
            personal[0] = 31;
            personal[1] = 45;

            double[] paying = new double[2];
            paying[0] = 65.0/60.0;
            paying[1] = 177.0/60.0;

            ValueForGen[] vans = new ValueForGen[4];
            ValueForGen[] trucks = new ValueForGen[6];

            ValueForGen van1 = new ValueForGen(35, 37, 0.2);
            ValueForGen van2 = new ValueForGen(38, 40, 0.35);
            ValueForGen van3 = new ValueForGen(41, 47, 0.3);
            ValueForGen van4 = new ValueForGen(48, 52, 0.15);

            ValueForGen truck1 = new ValueForGen(37, 42, 0.05);
            ValueForGen truck2 = new ValueForGen(43, 45, 0.1);
            ValueForGen truck3 = new ValueForGen(46, 47, 0.15);
            ValueForGen truck4 = new ValueForGen(48, 51, 0.4);
            ValueForGen truck5 = new ValueForGen(52, 55, 0.25);
            ValueForGen truck6 = new ValueForGen(56, 65, 0.05);

            vans[0] = van1;
            vans[1] = van2;
            vans[2] = van3;
            vans[3] = van4;

            trucks[0] = truck1;
            trucks[1] = truck2;
            trucks[2] = truck3;
            trucks[3] = truck4;
            trucks[4] = truck5;
            trucks[5] = truck6;

            int[][] discreteUniform = new int[1][];
            discreteUniform[0] = personal;


            ValueForGen[][] discreteEmpiric = new ValueForGen[2][];
            discreteEmpiric[0] = vans;
            discreteEmpiric[1] = trucks;

            double[][] continuosUniform = new double[1][];
            continuosUniform[0] = paying;

            values = new ValuesForGens();
            values.ArrDiscreteUniform = discreteUniform;
            values.ArrDiscreteEmpiric = discreteEmpiric;
            values.ArrContinuousUniform = continuosUniform;


            double mean = 60.0 / 23.0;
            SeedGenerator = new Random();
            ProbabilityGenerator = new Random(SeedGenerator.Next());
            CustomerGenerator = new ExponentialGenerator(SeedGenerator, mean);
            CheckingInGenerator = new TriangularGenerator(180.0/60.0, 695.0/60.0, 431.0/60.0, SeedGenerator);
            PayingTimeGenerator = new ContinuousUniformGenerator(values.ArrContinuousUniform[0][0], values.ArrContinuousUniform[0][1]);
            PersonalCarGenerator = new DiscreteUniformGenerator(values.ArrDiscreteUniform[0][0], values.ArrDiscreteUniform[0][1]);
            VanGenerator = new DiscreteEmpiricGenerator(SeedGenerator, values.ArrDiscreteEmpiric[0]);
            TruckGenerator = new DiscreteEmpiricGenerator(SeedGenerator, values.ArrDiscreteEmpiric[1]);
        }
    }
}
