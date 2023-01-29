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

namespace EX11
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Цикличный метод, вызываемый во входном рекурсивном методе
        /// </summary>
        private bool IsPalindrome(char[] chars, int from, int to)
        {
            if (from > to) return true;
            return chars[from] != chars[to] ? false : IsPalindrome(chars, from + 1, to - 1);
        }
        /// <summary>
        /// Входной рекурсивный метод для проверки строки на палиндромию
        /// </summary>
        /// <param name="input">Входная строка</param>
        public bool IsPalindrome(string input)
        {
            // Рекурсивно вызывается цикличный метод, в результате получая что-то вроде вложенного цикла

            return IsPalindrome(input.ToCharArray(), 0, input.Length - 1);
        }

        private void ProceedTaskAction(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(IsPalindrome(ArrayTextBox.Text) ? "YES" : "NO");
        }
    }
}
