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

namespace EX2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Выводит сообщение с суммой отрицательных чисел, количестве среди них четных и тех, чей модуль больше пяти
        /// </summary>
        /// <param name="array">Массив значений</param>
        private void ActionMethod(int[] array)
        {
            // Циклом проходимся по массиву, и по условию вначале проверяем значение итерации на отрицательность 
            // Если условие проходит, то к сумме элеменов прибавляем значение, если число четное или его модуль больше пяти,
            // То увеличиваем соответсвующую переменную

            int sum = 0, evenCount = 0, modCount = 0;
            foreach (int el in array)
            {
                if (el < 0)
                {
                    sum += el;
                    if (el % 2 == 0) evenCount++;
                    if (Math.Abs(el) > 5) modCount++;
                }
            }

            MessageBox.Show($"Сумма отрицательных чисел: {sum}\n" +
                $"Количество четных отрицательных чисел: {evenCount}\n" +
                $"Количество отрицательных чисел, чей модуль больше пяти: {modCount}");
        }

        private void ProceedTaskAction(object sender, RoutedEventArgs e)
        {
            ActionMethod(ArrayTextBox.Text.Split(' ').Select(x => Convert.ToInt32(x)).ToArray());
        }
    }
}
