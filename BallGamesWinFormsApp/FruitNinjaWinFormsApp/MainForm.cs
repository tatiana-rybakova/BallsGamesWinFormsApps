using Balls.Common;
using Timer = System.Windows.Forms.Timer;

namespace FruitNinjaWinFormsApp
{

    public partial class MainForm : Form
    {
        private Random random = new Random();
        private List<FruitBall> fruitBalls = new List<FruitBall>();
        private Timer commonTimer = new Timer();
        private Timer bananaTimer = new Timer();
        private bool activeBanana = false;


        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            commonTimer.Interval = 1000;
            commonTimer.Start();
            commonTimer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            for (int i = 4; i < 10; i++)
            {
                var ballNumber = random.Next(10);
                var ball = ballNumber == 4 ? new BombBall(this) : (ballNumber == 3 ? new BananaBall(this) : new FruitBall(this));

                fruitBalls.Add(ball);
                ball.Start();
                if (activeBanana)
                {
                    ball.GoSlow();
                }
            }
            commonTimer.Interval = random.Next(1000, 4000);
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var fruitBall in fruitBalls)
            {
                if (fruitBall.IsMoving() && fruitBall.Contains(e.X, e.Y))
                {
                    fruitBall.Stop();
                    if (fruitBall is BombBall)
                    {
                        EndGame();
                    }
                    else if (fruitBall is BananaBall)
                    {
                        activeBanana = true;
                        BananaEffect();
                    }
                    else
                    {
                        fruitBall.Clear();
                        scoreLabel.Text = (int.Parse(scoreLabel.Text) + 1).ToString();
                    }
                }
            }
        }

        private void BananaEffect()
        {
            foreach (var ball in fruitBalls)
            {
                ball.Clear();
                ball.GoSlow();
            }
            bananaTimer.Interval = 5000;
            bananaTimer.Start();
            bananaTimer.Tick += BananaTimer_Tick;
        }

        private void BananaTimer_Tick(object? sender, EventArgs e)
        {            
                activeBanana = false;
                bananaTimer.Stop();                          
        }      

        private void EndGame()
        {
            commonTimer.Stop();
            foreach (var fruitBall in fruitBalls)
            {
                fruitBall.Stop();
            }
            MessageBox.Show("Конец игры!");
        }
    }
}
