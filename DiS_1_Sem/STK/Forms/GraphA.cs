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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ScottPlot.Plottable;
using ScottPlot;

namespace Simulation.STK.Forms
{
    public partial class GraphA : Form
    {
        STKCore core;
        CancellationTokenSource cancelTokenSource;
        Task task;
        SignalPlotXY plot;
        public GraphA()
        {
            InitializeComponent();
            textBox1.Text = "17";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu form2 = new MainMenu();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            double[] plotX = new double[15];
            double[] plotY = new double[15];
            if (task != null)
            {
                if (task.IsCompleted.Equals(false))
                {
                    cancelTokenSource?.Cancel();
                }
            }




            plot = formsPlot1.Plot.AddSignalXY(plotX, plotY);
            formsPlot1.Plot.XAxis.Label("Number of clerks");
            formsPlot1.Plot.YAxis.Label("Average number of customers in check in queue");
            formsPlot1.Plot.Title("Clerks/Customers");
            formsPlot1.Refresh();



            for (int i = 1; i < 16; i++)
            {
                PriorityQueue<Event, double> timeline = new PriorityQueue<Event, double>();
                core = new STKCore(timeline, 0);
                cancelTokenSource = new CancellationTokenSource();
                core.CancelToken = cancelTokenSource.Token;
                core.NumberOfMechanics = Int32.Parse(textBox1.Text);
                core.TurboMode = true;
                core.MaxTime = 480;

                plotX[i - 1] = i;
                core.NumberOfClerks = i;
                task = Task.Run(() => core.Simulate(10000));
                await task;
                core.CountAverages();
                plotY[i - 1] = core.AvgCustomersInQCheckIn.Avg;

                plot.MaxRenderIndex = i - 1;
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
    }
}
