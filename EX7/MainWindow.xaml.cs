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

namespace EX7
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Заменяет отрицательные элементы входной матрицы с четными индексами на единицы
        /// </summary>
        /// <param name="input">Входная матрица</param>
        /// <returns>Результат замены</returns>
        private int[][] ProceedAction(int[][] input)
        {
            // Проходимся по всей матрице, на каждом числе проверяем индекс элемента на четность и отрицательность самого элемента
            // Если условие положительное - заменяет элемент на единицу
            // Возвращаем результат

            int[][] result = input;
            for (int i = 0; i < input.Length; i++)
                for (int j = 0; j < input.Length; j++)
                    if (((i + 1) % 2 == 0 || (j + 1) % 2 == 0) && result[i][j] < 0)
                        result[i][j] = 1;
            return result;
        }
        private void ProceedTaskAction(object sender, RoutedEventArgs e)
        {
            int[][] array = ArrayTextBox.Text.Split('\n').Select(x => x.Split(' ').Select(y => Convert.ToInt32(y)).ToArray()).ToArray();
            int[][] result = ProceedAction(array);
            MessageBox.Show(string.Join("\n", result.Select(x => string.Join("\t", x))));
        }
    }
}
