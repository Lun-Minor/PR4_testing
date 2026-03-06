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

namespace PR4_1_2

{
    public partial class SecondPage : Page
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (!TryParseDouble(tbX.Text, out double x) ||
                !TryParseDouble(tbB.Text, out double b))
            {
                MessageBox.Show("Введите корректные числа в поля x и b.",
                                "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                tbResult.Text = "—";
                return;
            }

            double prod = x * b;

            double f = GetF(x);

            double s;

            if (prod > 1 && prod < 10)
            {
                s = Math.Exp(f);
            }
            else if (prod > 12 && prod < 40)
            {
                s = Math.Sqrt(Math.Abs(f)) + 4 * b;
            }
            else
            {
                s = b * Math.Pow(f, 2);
            }

            tbResult.Text = s.ToString("F6");
        }

        private double GetF(double x)
        {
            if (rbSinh.IsChecked == true)
                return Math.Sinh(x);
            if (rbX2.IsChecked == true)
                return x * x;
            if (rbExp.IsChecked == true)
                return Math.Exp(x);

            return Math.Sinh(x);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbX.Clear();
            tbB.Clear();
            tbResult.Clear();
            rbSinh.IsChecked = true;
            tbX.Focus();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Visibility = Visibility.Collapsed;
                mainWindow.MainFrame.Content = null;
                mainWindow.mainContent.Visibility = Visibility.Visible;
            }
        }

        private bool TryParseDouble(string input, out double result)
        {
            result = 0;
            if (string.IsNullOrWhiteSpace(input)) return false;

            string cleaned = input.Trim().Replace(" ", "");

            if (double.TryParse(cleaned, out result)) return true;
            if (double.TryParse(cleaned.Replace(".", ","), out result)) return true;
            if (double.TryParse(cleaned.Replace(",", "."), out result)) return true;

            return false;
        }

        private void btnGO3_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
               // mainWindow.MainFrame.Navigate(new ThirdPage());
                mainWindow.MainFrame.Visibility = Visibility.Visible;
                mainWindow.mainContent.Visibility = Visibility.Collapsed;
            }
        }
    }
}