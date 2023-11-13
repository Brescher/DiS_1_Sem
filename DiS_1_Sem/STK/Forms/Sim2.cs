using ScottPlot.Renderable;
using ScottPlot.SnapLogic;
using Simulation.Cores.EventSimulation;
using Simulation.Generators;
using Simulation.NSStand;
using Simulation.STK.Events;
using Simulation.STK.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Simulation.STK.Forms
{
    public partial class Sim2 : Form, ISimDelegate
    {
        STKCore core;
        CancellationTokenSource cancelTokenSource;
        Task task;
        public Sim2()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.SetStyle(ControlStyles.DoubleBuffer |
                            ControlStyles.UserPaint |
                            ControlStyles.AllPaintingInWmPaint,
                            true);
            this.UpdateStyles();

            trackBar1.TickFrequency = 200;
            trackBar1.Value = 1000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu form2 = new MainMenu();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (core != null)
            {
                core.ServiceEventSleepTime = trackBar1.Value;
            }
        }

        private void StartSim(object sender, EventArgs e)
        {
            if (task != null)
            {
                if (task.IsCompleted.Equals(false))
                {
                    cancelTokenSource?.Cancel();
                }
            }

            PriorityQueue<Event, double> timeline = new PriorityQueue<Event, double>();
            core = new STKCore(timeline, 0);
            if (checkBox1.Checked)
            {
                core.TurboMode = true;
            }

            cancelTokenSource = new CancellationTokenSource();
            core.CancelToken = cancelTokenSource.Token;
            core.NumberOfClerks = Int32.Parse(textBox1.Text);
            core.NumberOfMechanics = Int32.Parse(textBox2.Text);
            core.IntervalOfSystemEvents = Int32.Parse(textBox3.Text);
            core.ServiceEventSleepTime = trackBar1.Value;
            core.MaxTime = Double.Parse(textBox6.Text) * 60;
            core.RegisterDelegate(this);
            task = Task.Run(() => core.Simulate(Int32.Parse(textBox5.Text)));
        }

        private void PauseSim(object sender, EventArgs e)
        {
            if (core.Pause == false)
            {
                core.Pause = true;
                button3.Text = "Unpause";
            }
            else
            {
                core.Pause = false;
                button3.Text = "Pause";
            }
        }

        private void StopSim(object sender, EventArgs e)
        {
            cancelTokenSource?.Cancel();
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                trackBar1.Value = 1000;
                trackBar1.Minimum = 1000;
                label19.Text = "Sleep time in seconds(1 - 2)";
                label23.Text = "1,0";
                if (core != null)
                {
                    core.ServiceEventSleepTime = trackBar1.Value;
                }
            }
            else
            {
                trackBar1.Minimum = 200;
                trackBar1.Value = 1000;
                label19.Text = "Sleep time in seconds(0,2 - 2)";
                label23.Text = "0,2";
                if (core != null)
                {
                    core.ServiceEventSleepTime = trackBar1.Value;
                }
            }
        }

        private void ShowStatistics(object sender, EventArgs e)
        {
            if (core != null)
            {
                core.CountAverages();
                Statistics myForm = new Statistics();
                myForm.Core = core;
                myForm.Show();
            }
        }

        private void Sim2_Load(object sender, EventArgs e)
        {
            textBox1.Text = "20";
            textBox2.Text = "20";
            textBox3.Text = "5";

            textBox5.Text = "100000";
            textBox6.Text = "8";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            GraphA form2 = new GraphA();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            GraphB form2 = new GraphB();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        void ISimDelegate.Refresh(EventSimulationCore core)
        {
            if (core.TurboMode == false)
            {
                this.BeginInvoke(() =>
                {

                    STKCore tempCore = (STKCore)core;

                    SuspendLayout();
                    textBox7.Text = "System time: " + TimeSpan.FromMinutes(tempCore.ActualTime + (9 * 60)).ToString() +
                                    "\r\nTotal number of customers: " + tempCore.NumberOfCustomers.ToString() +
                                    "\r\nNumber of customers in system: " + tempCore.CustomersInSystem.Count.ToString() +
                                    "\r\nCheck in queue size: " + tempCore.CustomersCheckIn.Count.ToString() +
                                    "\r\nParking in front of the workshop: " + tempCore.CustomersInspection.Count.ToString() + " / 5" +
                                    "\r\nPayment queue size: " + tempCore.CustomersPaying.Count.ToString() +
                                    "\r\nClerks free / total: " + tempCore.NumberOfFreeClerks.ToString() + " / " + tempCore.NumberOfClerks.ToString() +
                                    "\r\nMechanics free / total: " + tempCore.FreeMechanics.Count.ToString() + "/" + tempCore.NumberOfMechanics.ToString();


                    if (checkBox2.Checked)
                    {
                        dataGridView1.Rows.Clear();
                        dataGridView2.Rows.Clear();
                        dataGridView3.Rows.Clear();

                        foreach (STKCustomer cust in tempCore.CustomersInSystem.Values.ToList())
                        {
                            dataGridView1.Rows.Add(cust.Id, cust.Position);
                        }
                        foreach (Clerk clerk in tempCore.Clerks)
                        {
                            dataGridView2.Rows.Add(clerk.Id, clerk.Job, clerk.CustomerId);
                        }
                        foreach (Mechanic mechanic in tempCore.Mechanics)
                        {
                            dataGridView3.Rows.Add(mechanic.Id, mechanic.Job, mechanic.TypeOfCar, mechanic.CustomerId);
                        }
                    }

                    ResumeLayout();
                });
            }
            else
            {
                STKCore tempCore = (STKCore)core;
                this.BeginInvoke(() =>
                {
                    textBox7.Text = "Replication done: " + tempCore.RepsDone.ToString() +
                                    "\r\nAverage time in system: " + Math.Round(tempCore.AvgTimeInSystem.Avg, 4).ToString() +
                                    "\r\nAverage time in check in queue: " + Math.Round(tempCore.AvgTimeInQCheckIn.Avg, 4).ToString() +
                                    "\r\nAverage number of customers in check in queue: " + Math.Round(tempCore.AvgCustomersInQCheckIn.Avg, 4).ToString() +
                                    "\r\nAverage number of customers in system at the end: " + Math.Round(tempCore.AvgCustomersAtTheEnd.Avg, 4).ToString() +
                                    "\r\nAverage number of customers in system: " + Math.Round(tempCore.AvgCustomers.Avg, 4).ToString() +
                                    "\r\nAverage number of free clerks: " + Math.Round(tempCore.AvgFreeClerks.Avg, 4).ToString() +
                                    "\r\nAverage number of free mechanics: " + Math.Round(tempCore.AvgFreeMechanics.Avg, 4).ToString() +
                                    "\r\nAverage number of customers in system: " + Math.Round(tempCore.AvgCustomersInSystem.Avg, 4).ToString() +
                                    "\r\nTime in inspection: " + Math.Round(tempCore.TimeInInspection.Avg, 4).ToString() +
                                    "\r\nTime in check in: " + Math.Round(tempCore.TimeInCheckIn.Avg, 4).ToString();
                });
            }
        }
    }
}
