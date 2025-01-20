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

namespace _122_Rogosin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            // Получаем значения из TextBox
            if (double.TryParse(TextBox1.Text, out double i) && double.TryParse(TextBox2.Text, out double x))
            {
                double result = 0;

                // Проверяем, какая радиокнопка выбрана
                if (RadioButton1.IsChecked == true)
                {
                    // f(x) = sh(x)
                    result = Math.Sinh(x);
                }
                else if (RadioButton2.IsChecked == true)
                {
                    // f(x) = x^2
                    result = Math.Pow(x, 2);
                }
                else if (RadioButton3.IsChecked == true)
                {
                    // f(x) = e^x
                    result = Math.Exp(x);
                }

                // Определяем e в зависимости от i
                double resultE; // Изменено имя переменной
                if (i % 2 != 0 && x > 0) // i - нечетное, x > 0
                {
                    resultE = i * Math.Sqrt(result);
                }
                else if (i % 2 == 0 && x < 0) // i - четное, x < 0
                {
                    resultE = i / 2 * Math.Sqrt(Math.Abs(result));
                }
                else // иначе
                {
                    resultE = Math.Sqrt(Math.Abs(i * result));
                }

                // Выводим результат в TextBox3
                TextBox3.Text = resultE.ToString();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные значения для i и x.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            // Очищаем все TextBox
            TextBox1.Clear();
            TextBox2.Clear();
            TextBox3.Clear();
            RadioButton1.IsChecked = false;
            RadioButton2.IsChecked = false;
            RadioButton3.IsChecked = false;
        }
    }
}
