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

namespace EX13
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Получает количество групп символов, так например количество групп
        /// <br>в 110 будет равно 1;</br>
        /// <br>в 101 будет равно 2;</br>
        /// <br>в 100 будет равно 1;</br>
        /// <br>в 111 будет равно 1 и так далее...</br>
        /// </summary>
        /// <param name="input">Входная строка</param>
        /// <returns>Количество групп</returns>
        private int GetGroupsCount(string input)
        {
            // Проходимся по каждому символу входной строки, изначально инициализировав что-то вроде каретки,
            // Которая хранит в себе текущий символ, который потом используется для сравнения символа в итерации
            // И если они не равны и текущий символ равен 1, то мы изменяем каретку на 1 и прибавляем количество
            // Если они не равны и текущий символ равен 0, то мы просто изменяем знчение каретки на 0\
            // Далее просто возвращаем полученное количество

            char current = '0';
            int count = 0;

            foreach (char ch in input.ToCharArray())
            {
                if (ch != current && ch == '1')
                {
                    current = '1';
                    count++;
                }
                else if (ch != current && ch == '0')
                    current = '0';
            }
            return count;
        }
        /// <summary>
        /// Разделяет строку 
        /// </summary>
        /// <param name="input">Входная строка</param>
        /// <param name="count">Количество символов </param>
        /// <returns>Результат деления</returns>
        private string[] SplitStringByNChars(string input, int count)
        {
            // Проходимся по символам строки и после каждого N символа разделяем строку

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                stringBuilder.Append(input[i]);
                if ((i + 1) % count == 0) stringBuilder.Append("~");
            }
            return stringBuilder.ToString().Split('~');
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input">Массив строк</param>
        /// <returns></returns>
        private int GetStandCount(string[] input)
        {
            int count = 0;
            foreach (string el in input)
                count += GetGroupsCount(el);
            return count;
        }
        private void ProceedTaskAction(object sender, RoutedEventArgs e)
        {
            string[] array = SplitStringByNChars(ArrayTextBox.Text, Convert.ToInt32(TargetTextBox.Text.Split('*').Last()));
            MessageBox.Show($"{GetStandCount(array)}");
        }
    }
}
