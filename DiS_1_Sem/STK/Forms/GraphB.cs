using ScottPlot;
using ScottPlot.Plottable;
using Simulation.Cores.EventSimulation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation.STK.Forms
{
    public partial class GraphB : Form
    {
        STKCore core;
        CancellationTokenSource cancelTokenSource;
        Task task;
        SignalPlotXY plot;
        public GraphB()
        {
            InitializeComponent();
            textBox1.Text = "4";
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            double[] plotX = new double[16];
            double[] plotY = new double[16];
            if (task != null)
            {
                if (task.IsCompleted.Equals(false))
                {
                    cancelTokenSource?.Cancel();
                }
            }

            plot = formsPlot1.Plot.AddSignalXY(plotX, plotY);
            formsPlot1.Plot.XAxis.Label("Number of mechanics");
            formsPlot1.Plot.YAxis.Label("Average time in system");
            formsPlot1.Plot.Title("Mechanics/Time");
            formsPlot1.Refresh();

            for (int i = 0; i <= 15; i++)
            {
                PriorityQueue<Event, double> timeline = new PriorityQueue<Event, double>();
                core = new STKCore(timeline, 0);
                cancelTokenSource = new CancellationTokenSource();
                core.CancelToken = cancelTokenSource.Token;
                core.NumberOfClerks = Int32.Parse(textBox1.Text);
                core.TurboMode = true;
                core.MaxTime = 480;

                plotX[i] = i + 10;
                core.NumberOfMechanics = i + 10;
                task = Task.Run(() => core.Simulate(10000));
                await task;
                core.CountAverages();
                plotY[i] = core.AvgTimeInSystem.Avg;

                plot.MaxRenderIndex = i;
                formsPlot1.Plot.AxisAuto();
                formsPlot1.Refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sim2 form2 = new Sim2();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu form2 = new MainMenu();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}
