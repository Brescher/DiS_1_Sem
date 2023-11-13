using Simulation.NSStand;
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
    public partial class Statistics : Form
    {
        STKCore core;
        public Statistics()
        {
            InitializeComponent();
        }

        internal STKCore Core { get => core; set => core = value; }

        private void Statistics_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("Customers arrived",
                                    Math.Round(Core.AvgCustomers.Avg, 5),
                                    Math.Round(Core.AvgCustomers.Avg - Core.AvgCustomers.ConfidenceInterval95(), 5) + " | " + Math.Round(Core.AvgCustomers.Avg + Core.AvgCustomers.ConfidenceInterval95(), 5),
                                    Math.Round(Core.AvgCustomers.Avg - Core.AvgCustomers.ConfidenceInterval90(), 5) + " | " + Math.Round(Core.AvgCustomers.Avg + Core.AvgCustomers.ConfidenceInterval90(), 5)
                                    );

            dataGridView1.Rows.Add("Customers in system",
                                    Math.Round(Core.AvgCustomersInSystem.Avg, 5),
                                    Math.Round(Core.AvgCustomersInSystem.Avg - Core.AvgCustomersInSystem.ConfidenceInterval95(), 5) + " | " + Math.Round(Core.AvgCustomersInSystem.Avg + Core.AvgCustomersInSystem.ConfidenceInterval95(), 5),
                                    Math.Round(Core.AvgCustomersInSystem.Avg - Core.AvgCustomersInSystem.ConfidenceInterval90(), 5) + " | " + Math.Round(Core.AvgCustomersInSystem.Avg + Core.AvgCustomersInSystem.ConfidenceInterval90(), 5)
                                    );

            dataGridView1.Rows.Add("Customers in system at the end",
                                    Math.Round(Core.AvgCustomersAtTheEnd.Avg, 5),
                                    Math.Round(Core.AvgCustomersAtTheEnd.Avg - Core.AvgCustomersAtTheEnd.ConfidenceInterval95(), 5) + " | " + Math.Round(Core.AvgCustomersAtTheEnd.Avg + Core.AvgCustomersAtTheEnd.ConfidenceInterval95(), 5),
                                    Math.Round(Core.AvgCustomersAtTheEnd.Avg - Core.AvgCustomersAtTheEnd.ConfidenceInterval90(), 5) + " | " + Math.Round(Core.AvgCustomersAtTheEnd.Avg + Core.AvgCustomersAtTheEnd.ConfidenceInterval90(), 5)
                                    );

            dataGridView1.Rows.Add("Customers in check in queue",
                                    Math.Round(Core.AvgCustomersInQCheckIn.Avg, 5),
                                    Math.Round(Core.AvgCustomersInQCheckIn.Avg - Core.AvgCustomersInQCheckIn.ConfidenceInterval95(), 5) + " | " + Math.Round(Core.AvgCustomersInQCheckIn.Avg + Core.AvgCustomersInQCheckIn.ConfidenceInterval95(), 5),
                                    Math.Round(Core.AvgCustomersInQCheckIn.Avg - Core.AvgCustomersInQCheckIn.ConfidenceInterval90(), 5) + " | " + Math.Round(Core.AvgCustomersInQCheckIn.Avg + Core.AvgCustomersInQCheckIn.ConfidenceInterval90(), 5)
                                    );

            dataGridView1.Rows.Add("Time in system",
                                    Math.Round(Core.AvgTimeInSystem.Avg, 5),
                                    Math.Round(Core.AvgTimeInSystem.Avg - Core.AvgTimeInSystem.ConfidenceInterval95(), 5) + " | " + Math.Round(Core.AvgTimeInSystem.Avg + Core.AvgTimeInSystem.ConfidenceInterval95(), 5),
                                    Math.Round(Core.AvgTimeInSystem.Avg - Core.AvgTimeInSystem.ConfidenceInterval90(), 5) + " | " + Math.Round(Core.AvgTimeInSystem.Avg + Core.AvgTimeInSystem.ConfidenceInterval90(), 5)
                                    );

            dataGridView1.Rows.Add("Time in check in queue",
                                    Math.Round(Core.AvgTimeInQCheckIn.Avg, 5),
                                    Math.Round(Core.AvgTimeInQCheckIn.Avg - Core.AvgTimeInQCheckIn.ConfidenceInterval95(), 5) + " | " + Math.Round(Core.AvgTimeInQCheckIn.Avg + Core.AvgTimeInQCheckIn.ConfidenceInterval95(), 5),
                                    Math.Round(Core.AvgTimeInQCheckIn.Avg - Core.AvgTimeInQCheckIn.ConfidenceInterval90(), 5) + " | " + Math.Round(Core.AvgTimeInQCheckIn.Avg + Core.AvgTimeInQCheckIn.ConfidenceInterval90(), 5)
                                    );

            dataGridView1.Rows.Add("Time in payment in queue",
                                    Math.Round(Core.AvgTimeInQPayment.Avg, 5),
                                    Math.Round(Core.AvgTimeInQPayment.Avg - Core.AvgTimeInQPayment.ConfidenceInterval95(), 5) + " | " + Math.Round(Core.AvgTimeInQPayment.Avg + Core.AvgTimeInQPayment.ConfidenceInterval95(), 5),
                                    Math.Round(Core.AvgTimeInQPayment.Avg - Core.AvgTimeInQPayment.ConfidenceInterval90(), 5) + " | " + Math.Round(Core.AvgTimeInQPayment.Avg + Core.AvgTimeInQPayment.ConfidenceInterval90(), 5)
                                    );

            dataGridView1.Rows.Add("Free clerks",
                                    Math.Round(Core.AvgFreeClerks.Avg, 5),
                                    Math.Round(Core.AvgFreeClerks.Avg - Core.AvgFreeClerks.ConfidenceInterval95(), 5) + " | " + Math.Round(Core.AvgFreeClerks.Avg + Core.AvgFreeClerks.ConfidenceInterval95(), 5),
                                    Math.Round(Core.AvgFreeClerks.Avg - Core.AvgFreeClerks.ConfidenceInterval90(), 5) + " | " + Math.Round(Core.AvgFreeClerks.Avg + Core.AvgFreeClerks.ConfidenceInterval90(), 5)
                                    );

            dataGridView1.Rows.Add("Free mechanics",
                                    Math.Round(Core.AvgFreeMechanics.Avg, 5),
                                    Math.Round(Core.AvgFreeMechanics.Avg - Core.AvgFreeMechanics.ConfidenceInterval95(), 5) + " | " + Math.Round(Core.AvgFreeMechanics.Avg + Core.AvgFreeMechanics.ConfidenceInterval95(), 5),
                                    Math.Round(Core.AvgFreeMechanics.Avg - Core.AvgFreeMechanics.ConfidenceInterval90(), 5) + " | " + Math.Round(Core.AvgFreeMechanics.Avg + Core.AvgFreeMechanics.ConfidenceInterval90(), 5)
                                    );

        }
    }
}
