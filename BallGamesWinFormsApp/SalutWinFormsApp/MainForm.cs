using Balls.Common;
using Timer = System.Windows.Forms.Timer;

namespace SalutWinFormsApp
{
    public partial class MainForm : Form
    {   
        List<SalutBall> balls;
        private VerticalBall firstBall;
        private int ballsCount = 15;           
        public MainForm()
        {
            InitializeComponent();                    
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            firstBall = new VerticalBall(this);
            firstBall.TopReached += FirstBall_TopReached;
            firstBall.Start();           
        }

        private void FirstBall_TopReached(object? sender, TopReachedEventArgs e)
        {
             balls = new List<SalutBall>();
                for (int i = 0; i < ballsCount; i++)
                {
                    var ball = new SalutBall(this, e.CenterX, e.CenterY);
                    balls.Add(ball);
                    ball.Start();
                }               
        }
    }
}
