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

namespace EX6
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Заменяет элементы главной диагонали на нули
        /// </summary>
        /// <param name="input">Исходная матрица</param>
        /// <returns>Результат замены</returns>
        private int[][] ProceedAction(int[][] input)
        {
            // Циклом проходим по элементам диагонали и заменяем их на нули
            // Возвращаем полученный результат

            int[][] result = input;
            for (int i = 0; i < input.Length; i++)
                result[i][i] = 0;
            return result;
        }
        private void ProceedTaskAction(object sender, RoutedEventArgs e)
        {
            int[][] array = ArrayTextBox.Text.Split('\n').Select(x => x.Split(' ').Select(y => Convert.ToInt32(y)).ToArray()).ToArray();
            int[][] result = ProceedAction(array);
            MessageBox.Show(string.Join("\n", result.Select(x => string.Join(" ", x))));
        }
    }
}
