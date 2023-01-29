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

namespace EX9
{
    public partial class MainWindow : Window
    {
        private StringBuilder _result;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Добавляет все цифры числа в обратном порядке разделяя их пробелами
        /// </summary>
        /// <param name="input">Исходное число</param>
        private void ProceedAction(ulong input)
        {
            // Метод вызывает сам себя, пока входное число больше нуля
            // Если условие проходит, то число итерации добавляется в _result
            // И вызывается рекурсия

            if (input > 0)
            {
                _result.Append($"{input % 10} ");
                ProceedAction(input / 10);
            }
        }
        private void ProceedTaskAction(object sender, RoutedEventArgs e)
        {
            _result = new StringBuilder();
            ProceedAction(Convert.ToUInt64(ArrayTextBox.Text));
            MessageBox.Show(_result.ToString());
        }
    }
}
