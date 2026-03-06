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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (!TryParseDouble(tbX.Text, out double x) ||
                !TryParseDouble(tbY.Text, out double y) ||
                !TryParseDouble(tbZ.Text, out double z))
            {
                MessageBox.Show("Введите корректные числа во все поля (x, y, z).",
                                "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                tbResult.Text = "—";
                return;
            }

            
            double xClamped = Math.Max(-1.0, Math.Min(1.0, x));  

            
            if (Math.Abs(x) > 1.0)
            {
                MessageBox.Show("Функция arccos(x) определена только при -1 ≤ x ≤ 1.",
                                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            double abs_xy = Math.Abs(x - y);
            double numerator = x + 3 * abs_xy + x * x;
            double denominator = abs_xy * z + x * x;

            if (Math.Abs(denominator) < 1e-10)
            {
                
                MessageBox.Show("Знаменатель близок к нулю — вычисление невозможно.",
                                "Математическая ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            double fraction = numerator / denominator;

            double arctg = Math.Atan(x);
            double arccos = Math.Acos(xClamped);   

            double gamma = 5 * arctg - (1.0 / 4.0) * arccos * fraction;

           
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbX.Clear();
            tbY.Clear();
            tbZ.Clear();
            tbResult.Clear();
            tbX.Focus();
        }

        private bool TryParseDouble(string input, out double result)
        {
            result = 0;
            if (string.IsNullOrWhiteSpace(input))
                return false;

            string cleaned = input.Trim().Replace(" ", "");

            if (double.TryParse(cleaned, out result)) return true;
            if (double.TryParse(cleaned.Replace(".", ","), out result)) return true;
            if (double.TryParse(cleaned.Replace(",", "."), out result)) return true;

            return false;
        }

        private void btn_Go2SecondPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SecondPage());
            MainFrame.Visibility = Visibility.Visible;
            mainContent.Visibility = Visibility.Collapsed;
        }
    }
}