using Simulation.Generators;
using Simulation.Simulation;
using Simulation.ValuesForGenerators;
using ScottPlot;
using ScottPlot.Plottable;
using Simulation.NSStand;
using System;
using System.Threading;
using System.Threading.Tasks;
using Simulation.Cores.EventSimulation;

namespace Simulation
{
    public partial class Form1 : Form
    {
        SimulationTaskA simA;
        SimulationTaskB simB;
        ValuesForGens values;
        CancellationTokenSource cancelTokenSource;
        SignalPlotXY plot;
        public Form1()
        {
            InitializeComponent();
            initializeValuesForGens();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            simA = new SimulationTaskA(values);
            simB = new SimulationTaskB(values);
            cancelTokenSource = new CancellationTokenSource();
            simA.CancelToken = cancelTokenSource.Token;
            simB.CancelToken = cancelTokenSource.Token;

            formsPlot1.Plot.Clear();
            Array.Clear(simB.PlotX);
            Array.Clear(simB.PlotY);

            
            Task taskA = Task.Factory.StartNew(() => simA.Simulate(Int32.Parse(textBox1.Text)));
            Task taskB = Task.Factory.StartNew(() => simB.Simulate(Int32.Parse(textBox1.Text)));

            plot = formsPlot1.Plot.AddSignalXY(simB.PlotX, simB.PlotY);
            formsPlot1.Plot.XAxis.Label("PoËet replik·ciÌ");
            formsPlot1.Plot.YAxis.Label("Pravdepodobnosù");
            formsPlot1.Plot.Title("Pravdepodobnosù vËasnÈho prÌchodu");
            formsPlot1.Refresh();


            timer1.Enabled = true;
        }

        private void timerRender_Tick(object sender, EventArgs e)
        {
            if (simB.IndexPlot != 0)
            {
                plot.MaxRenderIndex = simB.IndexPlot - 1;
                plot.MinRenderIndex = (int)(simB.IndexPlot * 0.3);
                formsPlot1.Plot.AxisAuto();
                formsPlot1.Refresh();
            }
            label2.Text = simA.AvgWaitTimeTaskA.ToString() + " min";
            label3.Text = (simB.ProbabilityTaskB * 100).ToString() + " %";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cancelTokenSource?.Cancel();
        }

        private void initializeValuesForGens()
        {
            int[] ab = new int[2];
            ab[0] = 39;
            ab[1] = 64;

            int bc = 57;

            double[] de = new double[2];
            de[0] = 19;
            de[1] = 36;

            ValueForGen[] cm = new ValueForGen[7];
            ValueForGen[] ec = new ValueForGen[3];

            ValueForGen CM1 = new ValueForGen(3, 10, 0.2);
            ValueForGen CM2 = new ValueForGen(11, 20, 0.2);
            ValueForGen CM3 = new ValueForGen(21, 34, 0.3);
            ValueForGen CM4 = new ValueForGen(35, 52, 0.1);
            ValueForGen CM5 = new ValueForGen(53, 59, 0.15);
            ValueForGen CM6 = new ValueForGen(60, 95, 0.03);
            ValueForGen CM7 = new ValueForGen(96, 110, 0.02);

            ValueForGen EC1 = new ValueForGen(230, 243, 0.3);
            ValueForGen EC2 = new ValueForGen(244, 280, 0.5);
            ValueForGen EC3 = new ValueForGen(281, 350, 0.2);

            cm[0] = CM1;
            cm[1] = CM2;
            cm[2] = CM3;
            cm[3] = CM4;
            cm[4] = CM5;
            cm[5] = CM6;
            cm[6] = CM7;

            ec[0] = EC1;
            ec[1] = EC2;
            ec[2] = EC3;

            int[][] discreteUniform = new int[1][];
            discreteUniform[0] = ab;

            int[] deterministic = new int[1];
            deterministic[0] = bc;

            ValueForGen[][] discreteEmpiric = new ValueForGen[2][];
            discreteEmpiric[0] = cm;
            discreteEmpiric[1] = ec;

            double[][] continuosUniform = new double[1][];
            continuosUniform[0] = de;

            values = new ValuesForGens(discreteUniform, continuosUniform, discreteEmpiric, deterministic);
        }



        private void button4_Click(object sender, EventArgs e)
        {
            MainMenu myForm = new MainMenu();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }
    }
}