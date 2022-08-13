using Ball.Common;

namespace BillyardBallsWinFormsApp
{
    public partial class MainForm : Form
    {
        List<BillyardBall> balls;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            createButton.Enabled = true;
            clearButton.Enabled = false;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            createButton.Enabled = false;
            clearButton.Enabled = true;
            balls = new List<BillyardBall>();
            for (int i = 0; i < 10; i++)
            {
                var ball = new BillyardBall(this);
                balls.Add(ball);
                ball.Start();
                ball.OnHited += Ball_OnHited;
            }
        }

        private void Ball_OnHited(object sender, HitEventArgs e)
        {
            switch (e.Side)
            {
                case Side.Left: leftLabel.Text = (int.Parse(leftLabel.Text) + 1).ToString(); break;
                case Side.Right: rightLabel.Text = (int.Parse(rightLabel.Text) + 1).ToString(); break;
                case Side.Top: topLabel.Text = (int.Parse(topLabel.Text) + 1).ToString(); break;
                case Side.Down: downLabel.Text = (int.Parse(downLabel.Text) + 1).ToString(); break;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {

            createButton.Enabled = true;
            clearButton.Enabled = false;

            foreach (var ball in balls)
            {
                ball.Stop();
                ball.Clear();
                leftLabel.Text = "0";
                rightLabel.Text = "0";
                topLabel.Text = "0";
                downLabel.Text = "0";
            }
        }
    }
}
