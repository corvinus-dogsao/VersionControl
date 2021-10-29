using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string xmlstring = Consume();
            LoadXml(xmlstring);
            dataGridView1.Datasource = Rates;
            Charting();
        }
        private void Charting()
        {
            chartRateData.Datasource = Rates;
            Series series = chartRateData.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;
            var chartArea = chartRateData.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
        }

      
    }
}
