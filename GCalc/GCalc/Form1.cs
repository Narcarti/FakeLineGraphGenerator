using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GCalc
{
    public partial class Form1 : Form
    {


        Chart newChart;

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);

            this.Activate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            double[] x = GeneratePoints();
            double[] y = GeneratePoints();

            newChart = GenerateNewChart();

            newChart.Visible = true;

            newChart.Series.Add("XY");

            newChart.Series["XY"].IsXValueIndexed = true;

            newChart.Series["XY"].Color = Color.Red;
            newChart.Series["XY"].ChartType = SeriesChartType.Line;
            int pIdx = 0;
            while (pIdx < y.Length-1)
            {

                newChart.Series["XY"].Points.AddXY(pIdx,y[pIdx]);

                pIdx++;
            }
            newChart.Show();

            this.components = new Container();
            ChartArea chartArea1 = new ChartArea();
            ((ISupportInitialize)(this.newChart)).BeginInit();


            this.newChart.Dock = DockStyle.Fill;
            this.newChart.Location = new Point(0, 50);


            this.AutoScaleDimensions = new SizeF(15F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(500, 500);
            this.Controls.Add(this.newChart);
            this.Name = "Form1";
            this.Text = "FakeChart";
            this.Load += new EventHandler(this.Form1_Load);
            ((ISupportInitialize)(this.newChart)).EndInit();
            this.ResumeLayout(false);

            this.Focus();
        }

        public Chart GenerateNewChart()
        {
            Chart dChart = new Chart();
            ChartArea ca = new ChartArea();
            ca.AxisX = new Axis();
            ca.AxisX.IsStartedFromZero = true;
            dChart.Height = 300;
            dChart.Width = 100;
            dChart.ChartAreas.Add(ca);


            return dChart;
        }

        public double[] GeneratePoints()
        {
            Random rand = new Random();

            double[] ranNum = new double[100];

            for (int cnt = 0; cnt < 50; cnt++)
            {

                double num = rand.Next(0, 100) + 2;
                ranNum.SetValue(num, cnt);
            }

            return ranNum;
        }
    }
}
