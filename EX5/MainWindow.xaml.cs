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

namespace EX5
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Выводит сообщение с индексом и строкой в массиве, в которой самое большое количество символов А
        /// </summary>
        /// <param name="input">Массив строк</param>
        private void ProceedAction(string[] input)
        {
            // Циклом проходимся по всем элементам массива, на каждой итерации получаем количество символов А
            // Если оно больше максимального, индексу результата приравниваем индекс итерации, а максимальному количеству
            // Приравниваем полученное в текущей итерации количество символов
            // В конце просто выводим сообщение с полученными данными

            int maxCount = int.MinValue, index = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int count = input[i].Count(x => char.ToLower(x) == 'а');
                if (count > maxCount)
                {
                    index = i;
                    maxCount = count;
                }
            }
            MessageBox.Show($"В строке {index + 1} самое большое количество А:\n\n\n{input[index]}");
        }
        private void ProceedTaskAction(object sender, RoutedEventArgs e)
        {
            ProceedAction(StringTextBox.Text.Split('\n'));
        }
    }
}
