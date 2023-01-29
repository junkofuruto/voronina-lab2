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

namespace EX8
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <param name="input">Входная матрица</param>
        /// <returns>Возвращает сумму минимальных элементов строк</returns>
        private int ProceedAction(int[][] input)
        {
            // Проходимся циклом по строкам матрицы, с помощью Linq находим минимальный элемент, прибавляем его к результату

            int sum = 0;
            foreach (int[] el in input)
                sum += el.Min();
            return sum;
        }
        private void ProceedTaskAction(object sender, RoutedEventArgs e)
        {
            int[][] array = ArrayTextBox.Text.Split('\n').Select(x => x.Split(' ').Select(y => Convert.ToInt32(y)).ToArray()).ToArray();
            MessageBox.Show($"Сумма минимальных элементов строк равна {ProceedAction(array)}");
        }
    }
}
