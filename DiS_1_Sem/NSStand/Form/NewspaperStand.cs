using Simulation.Cores.EventSimulation;
using Simulation.NSStand;

namespace Simulation
{

    public partial class NewspaperStand : Form
    {
        NewspaperStandCore core;
        public NewspaperStand()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double time = 100000000;
            PriorityQueue<Event, double> timeline = new PriorityQueue<Event, double>();
            core = new NewspaperStandCore(timeline, 0);
            core.MaxTime = time;
            CustomerArrivalEventnss start = new CustomerArrivalEventnss(0, core);
            core.AddEvent(start);
            core.OneReplication();

            label3.Text = core.AvgWaitQueueTime.ToString();
            label4.Text = (core.AvgQueueSize).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu myForm = new MainMenu();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }
    }
}
