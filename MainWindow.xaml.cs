using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isGameOver;
        private bool firstPlayerTurn;
        private string turn;

        private CellValue[] cellValue;



        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        private void NewGame()
        {
            cellValue = new CellValue[9];

            for (int i=0; i<=cellValue.Length-1; i++)
            {
                cellValue[i] = CellValue.Empty;
            }
            firstPlayerTurn = true;
            isGameOver = false;

            Map.Children.Cast<Button>().ToList().ForEach(button => 
            {
                button.Content = string.Empty;
                button.Background = Brushes.Black;
            }
            );

         
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if (isGameOver == true)
            {
                NewGame();
                return;
                
            }

            var button = (Button)sender;
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            var index = column + (row * 3);

            if (cellValue[index] != CellValue.Empty)
            {
                
                return;
            }

            if (firstPlayerTurn)
                cellValue[index] = CellValue.Cross;
            else
                cellValue[index] = CellValue.Circle;

            if (firstPlayerTurn)
            {
                button.Content = "☭";
                button.Foreground = Brushes.LightGreen;
            }
            else
            {
                button.Content = "卐";
                button.Foreground = Brushes.HotPink;
            }

            if (firstPlayerTurn == true)
                firstPlayerTurn = false;
            else
                firstPlayerTurn = true;

            CheckForWinner();
        
        }

        private void CheckForWinner()
        {
            if (cellValue[0] != CellValue.Empty && (cellValue[0] & cellValue[1] & cellValue[2]) == cellValue[0])
            {
                isGameOver = true;

                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.White;
            }
            if (cellValue[0] != CellValue.Empty && (cellValue[0] & cellValue[3] & cellValue[6]) == cellValue[0])
            {
                isGameOver = true;

                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.White;

            }
            if (cellValue[0] != CellValue.Empty && (cellValue[0] & cellValue[4] & cellValue[8]) == cellValue[0])
            {
                isGameOver = true;

                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.White;
            }
            if (cellValue[1] != CellValue.Empty && (cellValue[1] & cellValue[4] & cellValue[7]) == cellValue[1])
            {
                isGameOver = true;

                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.White;
            }
            if (cellValue[2] != CellValue.Empty && (cellValue[2] & cellValue[4] & cellValue[6]) == cellValue[2])
            {
                isGameOver = true;

                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.White;
            }
            if (cellValue[2] != CellValue.Empty && (cellValue[2] & cellValue[5] & cellValue[8]) == cellValue[2])
            {
                isGameOver = true;

                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.White;
            }
            if (cellValue[3] != CellValue.Empty && (cellValue[3] & cellValue[4] & cellValue[5]) == cellValue[3])
            {
                isGameOver = true;

                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.White;
            }
            if (cellValue[6] != CellValue.Empty && (cellValue[6] & cellValue[7] & cellValue[8]) == cellValue[6])
            {
                isGameOver = true;

                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.White;
            }

            if (!cellValue.Any(x => x == CellValue.Empty) && !isGameOver)
            {
                isGameOver = true;
                Map.Children.Cast<Button>().ToList().ForEach(button =>
                {
                   
                    button.Background = Brushes.IndianRed;
                }
           );
            }
        }

    }
}
