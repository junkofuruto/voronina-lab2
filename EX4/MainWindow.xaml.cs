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

namespace EX4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// После каждого третьего символа исходной строки добавляет пробел
        /// </summary>
        /// <param name="input">Исходная строка</param>
        /// <returns></returns>
        private string PreceedAction(string input)
        {
            // Циклом проходимся по исходной строке, если номер символа нацело делится на 3 -
            // Помимо самого символа добавляем в билдер пробел

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                stringBuilder.Append(input[i]);
                if ((i + 1) % 3 == 0) stringBuilder.Append(' ');
            }

            return stringBuilder.ToString();
        }
        private void ProceedTaskAction(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(PreceedAction(StringTextBox.Text));
        }
    }
}
