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

namespace EX10
{
    public partial class MainWindow : Window
    {
        private StringBuilder _result;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <param name="number">Входное число</param>
        /// <returns>Является ли число простым</returns>
        private bool IsPrime(ulong number)
        {
            // Обычная матиматическая проверка числа на простоту числа

            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (ulong)Math.Floor(Math.Sqrt(number));

            for (ulong i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        /// <summary>
        /// В _return рекурсионно добавляет все простые делители числа
        /// </summary>
        /// <param name="input">Число</param>
        /// <param name="divisor">Делитель</param>
        private void ProceedAction(ulong input, ulong divisor)
        {
            // Пока делитель меньше исходного числа, вызывется рекурсия, в которой
            // Проверяется, нацело ли делится делитель на число, и является ли делитель простым числом
            // Если условие проходит, то делитель добавляется в _result

            if (divisor <= input)
            {
                if (input % divisor == 0 && IsPrime(divisor))
                    _result.Append($"{divisor}; ");
                ProceedAction(input, divisor + 1);
            }
        }
        private void ProceedTaskAction(object sender, RoutedEventArgs e)
        {
            _result = new StringBuilder();
            ProceedAction(Convert.ToUInt64(ArrayTextBox.Text), 1u);
            MessageBox.Show(_result.ToString());
        }
    }
}
