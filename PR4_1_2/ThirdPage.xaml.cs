using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms.DataVisualization.Charting;

namespace PR4_1_2



{
    public partial class ThirdPage : Page
    {
        private Chart chart;

        public ThirdPage()
        {
            InitializeComponent();

            
            chart = new Chart();

            var chartArea = new ChartArea("MainArea")
            {
                AxisX = { Title = "x", MajorGrid = { Enabled = true }, LabelStyle = { Format = "F2" } },
                AxisY = { Title = "y", MajorGrid = { Enabled = true }, LabelStyle = { Format = "F2" } }
            };
            chart.ChartAreas.Add(chartArea);

            var series = new Series("Series1")
            {
                ChartType = SeriesChartType.Line,

                BorderWidth = 2,
                LegendText = "y(x)"
            };
            chart.Series.Add(series);

            var legend = new Legend("Legend")
            {
                Docking = Docking.Top,
                Alignment = System.Drawing.StringAlignment.Center
            };
            chart.Legends.Add(legend);

            
            var host = new System.Windows.Forms.Integration.WindowsFormsHost { Child = chart };
            chartContainer.Children.Add(host);
        }

        private void btnBuild_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(tbX1.Text.Replace(".", ","), out double x1) ||
                !double.TryParse(tbX2.Text.Replace(".", ","), out double x2) ||
                !double.TryParse(tbH.Text.Replace(".", ","), out double h) ||
                !double.TryParse(tbB.Text.Replace(".", ","), out double b))
            {
                MessageBox.Show("Введите корректные числа во все поля.", "Ошибка ввода");
                return;
            }

            if (x1 >= x2 || h <= 0)
            {
                MessageBox.Show("x от должно быть меньше x до, шаг h > 0.", "Неверные границы");
                return;
            }

            chart.Series["Series1"].Points.Clear();

            StringBuilder table = new StringBuilder();
            table.AppendLine("     x           y");

            double x = x1;
            while (x <= x2 + 1e-10)
            {
                double y = CalculateY(x, b);
                chart.Series["Series1"].Points.AddXY(x, y);
                table.AppendLine($"{x,10:F3}   {y,12:F6}");
                x += h;
            }

            tbTable.Text = table.ToString();
            chart.Invalidate();
        }

        private double CalculateY(double x, double b)
        {
            double cubeSum = Math.Pow(x, 3) + Math.Pow(b, 3);
            double cubeRoot = Math.Pow(cubeSum, 1.0 / 3.0);
            return 9 * (x + 15 * cubeRoot);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbX1.Clear();
            tbX2.Clear();
            tbH.Clear();
            tbB.Clear();
            tbTable.Clear();

            chart.Series["Series1"].Points.Clear();
            chart.Invalidate();
        }

        private void btnClose(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
