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

            gameTimer.Tick += GameTimerEvent; // for hver vores gameTimer tick call then vores function 
            gameTimer.Interval = TimeSpan.FromMilliseconds(60); // det er hvor tid være imellem vores tick
            gameTimer.Start();
            T1.Start();

            test(0, 0);

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



        private void KeyIsDown(object sender, KeyEventArgs e) // vores function til chekke vores tats er press ned
        {
            if (e.Key == Key.Left)
            {
                goLeft = true; //bruger i function GameTimerEvent til at så længe sandt rykker skal sig som  den når tats er pressed ned 
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

        private void KeyIsUp(object sender, KeyEventArgs e) // vores function skifte bool false når key ikke pressed så vi forsætter med bevæge os
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
            try // den prøver code CreateRectangle(a, b) hvis fejl så ned catch
            {
                CreateRectangle(a, b);
            }
            catch (DivideByZeroException ex) // catch er hvordan vores fejl 
            {
                if (a == 0) { a = 10; } //   hvis a eller b er 0 så sættet til vores andre værdi så for fejlen
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

                do // do while er et antal gang som vores code i køre i loop
                {
                    Thread.Sleep(5000); // foræller vores tråd at den skal ikke gøre noget i 5 sec 
                    this.Dispatcher.BeginInvoke((Action)(() =>
                    player.Height += 2));

                    i++;
                }
                while (i < 30);

            }

        }

    }
}






