using Balls.Common;

namespace CatchBallWindowsFormsApp
{
    public partial class MainForm : Form
    {
        List<RandomMoveBall> balls;
        private int count = 0;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            createButton.Enabled = true;
            clearButton.Enabled = false;
        }

        private void createButton_Click_1(object sender, EventArgs e)
        {
            createButton.Enabled = false;
            clearButton.Enabled = true;
            balls = new List<RandomMoveBall>();
            for (int i = 0; i < 10; i++)
            {
                var ball = new RandomMoveBall(this);
                balls.Add(ball);
                ball.Start();
            }
        }

        private void clearButton_Click_1(object sender, EventArgs e)
        {
            createButton.Enabled = true;
            clearButton.Enabled = false;

            foreach (var ball in balls)
            {
                ball.Clear();
            }
            ballsCountLabel.Text = "0";
        }

        private void MainForm_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (balls != null)
            {
                foreach (var ball in balls)
                {
                    if (ball.Contains(e.X, e.Y) && ball.IsMoving())
                    {
                        ball.Stop();
                        count++;
                    }
                }
                ballsCountLabel.Text = count.ToString();
            }
        }
    }
}
