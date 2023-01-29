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

namespace EX3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Удаляет все символы '*' и удваивает оставшиевся символы 
        /// </summary>
        /// <param name="input">Исходная строка</param>
        /// <returns></returns>
        private string ProceedAction(string input)
        {
            // Сплитим строку по символу '*', потом объединяем её в одну, далее выбираем каждый символ дважды

            return string.Join("", string.Join("", input.Split('*')).Select(x => $"{x}{x}"));
        }
        private void ProceedTaskAction(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(ProceedAction(StringTextBox.Text));
        }
    }
}
