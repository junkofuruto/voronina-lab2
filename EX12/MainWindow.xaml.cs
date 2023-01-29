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

namespace EX12
{
    /// <summary>
    /// Класс, содержащий данные о команде, её номер, очки за игры и
    /// реализующий метод получения итогового количество очков
    /// </summary>
    public sealed class Team
    {
        public Team(int identificator, int[] gameScores)
        {
            Identificator = identificator;
            GameScores = gameScores;
        }

        /// <summary>
        /// Номер команды
        /// </summary>
        public int Identificator { get; set; }
        /// <summary>
        /// Очки за игры
        /// </summary>
        public int[] GameScores { get; set; }
        /// <returns>Итоговое количество очков за все игры</returns>
        public int GetFinalScore()
        {
            return GameScores.Sum();
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Инициализирует команды
        /// </summary>
        /// <param name="scores">Матрица очков игр</param>
        /// <returns>Список команд</returns>
        private List<Team> FillTeamList(int[][] scores)
        {
            // Циклом проходимся по строкам матрицы счета, на каждой итерации добавляем в список
            // Новую команду в соответсвии с конструктором класса, далее сортируем список по очкам

            List<Team> teams = new List<Team>();
            for (int i = 0; i < scores.Length; i++)
                teams.Add(new Team(i + 1, scores[i]));
            teams = teams.OrderBy(x => x.GetFinalScore()).Reverse().ToList();
            return teams;
        }
        /// <summary>
        /// Создает строку с командами в соответсвии с шаблоном "Команда [НОМЕР КОМАНДЫ] заняла [ПОЗИЦИЯ КОМАНДЫ] место с [СУММА ОЧКОВ] очками"
        /// </summary>
        /// <param name="teams">Список команд</param>
        private string BuildResult(List<Team> teams)
        {
            // Циклом проходимся по списку команд и на каждой итерации в соответсвии с шаблоном
            // Добавляем строку с данными в билдер, в конце просто возвращем его как результат

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < teams.Count; i++)
                result.Append($"Команда {teams[i].Identificator} заняла {i + 1} место с {teams[i].GetFinalScore()} очками\n");
            return result.ToString();
        }
        private void ProceedTaskAction(object sender, RoutedEventArgs e)
        {
            int[][] scores = ArrayTextBox.Text.Split('\n').Select(x => x.Split(' ').Select(y => Convert.ToInt32(y)).ToArray()).ToArray();
            List<Team> teams = FillTeamList(scores);
            MessageBox.Show(BuildResult(teams));
        }
    }
}
