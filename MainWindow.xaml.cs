using LCRGame.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LCRGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int STARTING_CHIPS = 3;

        Random randomGen = new Random();
        ObservableCollection<LineSeries> lineChart = new ObservableCollection<LineSeries>();

        public MainWindow()
        {
            InitializeComponent();

            gamesChart.ItemsSource = lineChart;
        }

        private void ClearOutput()
        {
            gridPlayers.Children.Clear();
            lineChart.Remove(x => x.IsSelected);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            cmbPreset.SelectedItem = null;
            txtPlayers.Text = null;
            txtGames.Text = null;

            ClearOutput();
        }

        private int PlayLCR(int startingChips, int playerNum)
        {
            int turnNum = 0;

            var rng = new Random();
            //Create a list of chips
            var players = Enumerable.Repeat(startingChips, playerNum).ToList();
            //Loop as long any player still has chips
            for (turnNum = 0;
                    players.Any(c => c > 0);
                    //And print the result every iteration
                    turnNum++)
                //Get a random number within the range of dice and loop for...
                for (int k = 0, randomNum = rng.Next(6);
                    //either 3 or the amount of chips we have, whichever is smaller
                    k++ < Math.Min(players[turnNum % playerNum], 3);
                    //Increment either the right player if the random number is 1, else increment the right player if it is 0
                    players[((randomNum < 1 ? -1 : 1) + turnNum + playerNum) % playerNum] += randomNum < 2 ? 1 : 0,
                    //Decrement current player if the die roll is under 3
                    players[turnNum % playerNum] -= randomNum < 3 ? 1 : 0)
                    ;

            return turnNum;
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtGames.Text) || string.IsNullOrEmpty(txtPlayers.Text))
            {
                txtError.Visibility = Visibility.Visible;
                txtError.Text = "Games and Players are required!";
                txtError.Foreground = Brushes.Red;

                return;
            }

            ClearOutput();

            int players = Convert.ToInt32(txtPlayers.Text);
            int games = Convert.ToInt32(txtGames.Text);

            var turns = Enumerable.Repeat(1, games).Select(_ => PlayLCR(STARTING_CHIPS, players)).ToList();

            //Draw the Graph output
            DrawGraphOutput(turns, games);

            int winner = randomGen.Next(players);

            for (int i = 0; i < players; i++)
            {
                gridPlayers.Columns = players;

                PlayerControl playerControl = new PlayerControl();
                playerControl.NumberOfPlayers = (i + 1).ToString();

                if (i == winner)
                    playerControl.FillColor = true;

                gridPlayers.Children.Add(playerControl);
            }
        }

        private void DrawGraphOutput(List<int> turns, int games)
        {
            var totalValue = 0;

            gamesChart.XMax = games;
            gamesChart.SkipLabels = games / 10;

            LineSeries newChart = new LineSeries();

            for (int i = 0; i < games; i++)
            {
                totalValue += turns[i];

                if (turns.Min() == turns[i])
                {
                    gamesChart.ShortestTurn = true;
                    gamesChart.LongestTurn = false;
                }
                else if (turns.Max() == turns[i])
                {
                    gamesChart.ShortestTurn = false;
                    gamesChart.LongestTurn = true;
                }
                else
                {
                    gamesChart.ShortestTurn = false;
                    gamesChart.LongestTurn = false;
                }

                newChart.ChartData.Add(new DataPoint() { TotalGames = i, Turns = turns[i] });
            }

            lineChart.Add(newChart);

            //AverageChart
            LineSeries newAverageChart = new LineSeries();
            var averageValue = totalValue / games;
            for (int i = 0; i < games; i++)
            {
                newAverageChart.ChartData.Add(new DataPoint() { TotalGames = i, Turns = averageValue });
            }

            lineChart.Add(newAverageChart);
        }
    }
}