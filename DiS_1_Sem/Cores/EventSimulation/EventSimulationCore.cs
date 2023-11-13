using Simulation.STK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Cores.EventSimulation
{
    internal abstract class EventSimulationCore : SimulationCore
    {
        protected PriorityQueue<Event, double> timeline;
        protected List<ISimDelegate> delegates = new List<ISimDelegate>();
        private double actualTime, maxTime;
        private bool pause, turboMode;
        protected int serviceEventSleepTime, intervalOfSystemEvents;


        protected EventSimulationCore(PriorityQueue<Event, double> timeline_, double actualTime_)
        {
            timeline = timeline_;
            ActualTime = actualTime_;
            Pause = false;
            TurboMode = false;
        }

        public double ActualTime { get => actualTime; set => actualTime = value; }
        public double MaxTime { get => maxTime; set => maxTime = value; }
        public bool Pause { get => pause; set => pause = value; }
        public bool TurboMode { get => turboMode; set => turboMode = value; }
        public int IntervalOfSystemEvents { get => intervalOfSystemEvents; set => intervalOfSystemEvents = value; }
        public int ServiceEventSleepTime { get => serviceEventSleepTime; set => serviceEventSleepTime = value; }

        public void AddEvent(Event event_)
        {
            if (ActualTime <= event_.TimeOfEvent)
            {
                timeline.Enqueue(event_, event_.TimeOfEvent);
            }
            else
            {
                throw new Exception("Can´t travel back in time!");
            }
        }

        public override void OneReplication()
        {
            if (turboMode == false)
            {
                SystemEvent sysEv = new SystemEvent(0, this);
                AddEvent(sysEv);
            }
            Event helpEvent;
            while (timeline.Count != 0 || ActualTime > MaxTime)
            {
                while (pause)
                {
                    Thread.Sleep(350);
                }
                helpEvent = timeline.Dequeue();
                ActualTime = helpEvent.TimeOfEvent;
                if (ActualTime > MaxTime || CancelToken.IsCancellationRequested)
                {
                    break;
                }

                helpEvent.Execute();
                if (turboMode == false)
                {
                    RefreshGUI();
                }

            }
        }

        public void RegisterDelegate(ISimDelegate delegate_)
        {
            delegates.Add(delegate_);
        }

        protected void RefreshGUI()
        {
            foreach (ISimDelegate dele in delegates.OfType<ISimDelegate>())
            {
                dele.Refresh(this);
            }
        }
    }
}
