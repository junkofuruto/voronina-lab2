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

namespace EX1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод поиска вхождений целевой переменной в массив
        /// </summary>
        /// <param name="array">Массив значений</param>
        /// <param name="target">Целевая переменная</param>
        /// <returns></returns>
        private int GetArrayTargetEntries(int[] array, int target)
        {
            // Cоздаем счетчик входов целевой переменной, циклом проходимся по массиву
            // Если на итерации элемент равне целевой переменной, увеличиваем счетчик

            int entriesCount = 0;
            foreach (int el in array)
                if (el == target) entriesCount++;
            return entriesCount;
        }

        private void ProceedTaskAction(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Вхождений целевой переменной в массив итого: " +
                $"{this.GetArrayTargetEntries(ArrayTextBox.Text.Split(' ').Select(x => Convert.ToInt32(x)).ToArray(), Convert.ToInt32(TargetTextBox.Text))}");
        }
    }
}
