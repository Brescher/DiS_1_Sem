using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Simulation.Statistics
{
    internal class Average
    {
        private double sum, count, avg, sumsq;

        public double Sum { get => sum; set => sum = value; }
        public double Count { get => count; set => count = value; }
        public double Avg { get => avg; set => avg = value; }
        public double Sumsq { get => sumsq; set => sumsq = value; }

        public Average() 
        {
            Sum = 0;
            Count = 0;
            Avg = 0;
        }

        public void CountAverage()
        {
            avg = sum / count;
        }

        public double SampleStandardDeviation()
        {
            return Math.Sqrt((Sumsq - (Math.Pow(sum, 2) / count)) / (count - 1));
        }

        public double ConfidenceInterval90()
        {
            double ret;
            return ret =  (SampleStandardDeviation() * 1.645) / Math.Sqrt(count);
        }

        public double ConfidenceInterval95()
        {
            return (SampleStandardDeviation() * 1.96) / Math.Sqrt(count);
        }
    }
}
