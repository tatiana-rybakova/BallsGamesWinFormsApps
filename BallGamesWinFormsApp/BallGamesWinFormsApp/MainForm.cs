using Ball.Common;

namespace BallGamesWinFormsApp
{
    public partial class MainForm : Form
    {
        List<RandomMoveBall> balls;
        public MainForm()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            createButton.Enabled = false;
            stopButton.Enabled = true;
            balls = new List<RandomMoveBall>();
            for (int i = 0; i < 10; i++)
            {
                var ball = new RandomMoveBall(this);
                balls.Add(ball);
                ball.Start();

            }                       
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            createButton.Enabled = false;
            stopButton.Enabled = false;
            clearButton.Enabled = true;

            for (int i = 0; i < 10; i++)
            {
                balls[i].Stop();                
            }
            MessageBox.Show(CountBalls().ToString());
        }

        private int CountBalls()
        {
            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                if (balls[i].Catched()) count++;
            }
            return count;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            createButton.Enabled = true;
            stopButton.Enabled = false;
            clearButton.Enabled = false;

            foreach (var ball in balls)
            {
                ball.Clear();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            createButton.Enabled = true;
            stopButton.Enabled = false;
            clearButton.Enabled = false;
        }
    }
}