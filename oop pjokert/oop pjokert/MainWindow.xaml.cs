using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Timer_and_Keyboard_MOO_ICT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Thread T1;

        bool goLeft, goRight, goUp, goDown;
        int playerSpeed = 8;




        DispatcherTimer gameTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            T1 = new Thread(age);

            myCanvas.Focus();

            gameTimer.Tick += GameTimerEvent;
            gameTimer.Interval = TimeSpan.FromMilliseconds(60);
            gameTimer.Start();
            T1.Start();

            test(0, 0);
            // age();

        }


        private void GameTimerEvent(object sender, EventArgs e)
        {
            if (goLeft == true && Canvas.GetLeft(player) > 5)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) - playerSpeed);
            }
            if (goRight == true && Canvas.GetLeft(player) + (player.Width + 20) < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) + playerSpeed);
            }
            if (goUp == true && Canvas.GetTop(player) > 5)
            {
                Canvas.SetTop(player, Canvas.GetTop(player) - playerSpeed);
            }
            if (goDown == true && Canvas.GetTop(player) + (player.Height * 2) < Application.Current.MainWindow.Height)
            {
                Canvas.SetTop(player, Canvas.GetTop(player) + playerSpeed);
            }

        }



        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                goLeft = true;
            }
            if (e.Key == Key.Right)
            {
                goRight = true;
            }
            if (e.Key == Key.Up)
            {
                goUp = true;
            }
            if (e.Key == Key.Down)
            {
                goDown = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                goLeft = false;
            }
            if (e.Key == Key.Right)
            {
                goRight = false;
            }
            if (e.Key == Key.Up)
            {
                goUp = false;
            }
            if (e.Key == Key.Down)
            {
                goDown = false;
            }
        }

        public void test(int a, int b)
        {
            try
            {
                CreateRectangle(a, b);
            }
            catch (DivideByZeroException ex)
            {
                if (a == 0) { a = 10; }
                if (b == 0) { b = 20; }
                CreateRectangle(a, b);

            }
        }

        void CreateRectangle(int x, int y)
        {
            var newEnemy = new Rectangle
            {
                Tag = "enemy",
                Height = 1000 / x,
                Width = 1000 / y,
                Fill = Brushes.Gray
            };

            Canvas.SetTop(newEnemy, 10);
            Canvas.SetLeft(newEnemy, 200);
            myCanvas.Children.Add(newEnemy);
        }


        public void age()
        {

            int i = 0;
            {

                do
                {
                    Thread.Sleep(5000);
                    this.Dispatcher.BeginInvoke((Action)(() =>
                    // changePlayerHeight();
                    player.Height += 2));

                    i++;
                }
                while (i < 30);

            }

        }

    }

    public class Humen : Creatures
    {
        // public string Name = " Humen";

        public Humen(string race, int height, int width, int health, int damage) : base(race, height, width, health, damage)
        { }
        private string race = "Humen";
        private int Height = 10;
        private int Width = 0;
        private int Health = 0;
        private int Damage = 0;





    }


}



/* public string Race = "Humen";
 public int Height = 10;
 public int Width = 10;
 public int health = 10;
 public int damage = 10;

 public Humen(string? race, int height, int width, int health, int damage) : base(race, height, width, health, damage)
 {
 }*/




