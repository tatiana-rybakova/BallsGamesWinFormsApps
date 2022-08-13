using Balls.Common;
using Timer = System.Windows.Forms.Timer;

namespace DifusionWinFormsApp
{
    public partial class MainForm : Form
    {
        List<BillyardBall> blueBalls;
        List<BillyardBall> redBalls;
        List<BillyardBall> allBalls;
        private int ballsCount = 10;
        private Timer timer = new Timer();
        public MainForm()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            ShowCenterLine();
            int blueLeftCount = 0;
            int redLeftCount = 0;

            foreach (var blueBall in blueBalls)
            {
                if (blueBall.IsLeft())
                {
                    blueLeftCount++;
                }
            }
            foreach (var redBall in redBalls)
            {
                if (redBall.IsLeft())
                {
                    redLeftCount++;
                }
            }
            if (blueLeftCount == redLeftCount && blueLeftCount == ballsCount / 2)
            {
                foreach (var ball in allBalls)
                {
                    ball.Stop();
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            allBalls = new List<BillyardBall>();
            blueBalls = new List<BillyardBall>();
            redBalls = new List<BillyardBall>();
            for (int i = 0; i < ballsCount; i++)
            {
                var brush = Brushes.Blue;
                var ball = new BillyardBall(this, brush, 0, ClientSize.Width / 2);
                blueBalls.Add(ball);
                allBalls.Add(ball);
                ball.Show(brush);
            }
            redBalls = new List<BillyardBall>();
            for (int i = 0; i < ballsCount; i++)
            {
                var brush = Brushes.Red;
                var ball = new BillyardBall(this, brush, ClientSize.Width / 2, ClientSize.Width);
                redBalls.Add(ball);
                allBalls.Add(ball);
                ball.Show(brush);
            }
        }

        private void ShowCenterLine()
        {
            var graphics = CreateGraphics();
            graphics.DrawLine(Pens.Black, ClientSize.Width / 2, 0, ClientSize.Width / 2, ClientSize.Height);
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var blueBall in blueBalls)
            {
                if (!blueBall.IsMoving())
                {
                    blueBall.Start();
                    blueBall.OnHited += BlueBall_OnHited;
                }
                else
                {
                    blueBall.Stop();
                }

            }
            foreach (var redBall in redBalls)
            {
                if (!redBall.IsMoving())
                {
                    redBall.Start();
                    redBall.OnHited += RedBall_OnHited;
                }
                else
                {
                    redBall.Stop();
                }
            }
        }

        private void BlueBall_OnHited(object? sender, HitEventArgs e)
        {
            switch (e.Side)
            {
                case Side.Left: blueBallLeftLabel.Text = (int.Parse(blueBallLeftLabel.Text) + 1).ToString(); break;
                case Side.Right: blueBallRightLabel.Text = (int.Parse(blueBallRightLabel.Text) + 1).ToString(); break;
                case Side.Top: blueBallTopLabel.Text = (int.Parse(blueBallTopLabel.Text) + 1).ToString(); break;
                case Side.Down: blueBallDownLabel.Text = (int.Parse(blueBallDownLabel.Text) + 1).ToString(); break;
            }
        }

        private void RedBall_OnHited(object? sender, HitEventArgs e)
        {
            switch (e.Side)
            {
                case Side.Left: redBallLeftLabel.Text = (int.Parse(redBallLeftLabel.Text) + 1).ToString(); break;
                case Side.Right: redBallRightLabel.Text = (int.Parse(redBallRightLabel.Text) + 1).ToString(); break;
                case Side.Top: redBallTopLabel.Text = (int.Parse(redBallTopLabel.Text) + 1).ToString(); break;
                case Side.Down: redBallDownLabel.Text = (int.Parse(redBallDownLabel.Text) + 1).ToString(); break;
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            foreach (var ball in allBalls)
            {
                ball.Show(ball.brush);
            }
        }
    }
}