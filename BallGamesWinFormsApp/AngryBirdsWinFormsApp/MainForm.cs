using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace AngryBirdsWinFormsApp
{
    public partial class MainForm : Form
    {
        private Bird bird;
        private Pig pig;
        private Timer timer = new Timer();
        public MainForm()
        {
            InitializeComponent();
            timer.Interval = 20;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (!bird.IsMoving())
            {
                CreateNewBird();
            }
            if (bird.IsOutSide())
            {
                CreateNewBird();
            }
            if (bird.IsTouching(pig))
            {
                scoreLabel.Text = (int.Parse(scoreLabel.Text)+1).ToString();
                CreateNewBird();
                CreateNewPig();
            }
        }

        private void CreateNewBird()
        {
            timer.Stop();
            if (bird != null)
            {
                bird.Stop();
                bird.Clear();
            }
            bird = new Bird(this);
            bird.Show(bird.brush);
        }

        private void CreateNewPig()
        {
            if (pig != null)
            {                
                pig.Clear();
            }
            pig = new Pig(this);
            pig.Show(pig.brush);
        }
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            bird.SetSpeed(e.X, e.Y);
            timer.Start();
            bird.Start();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            scoreLabel.Text = "0";

            CreateNewBird();           

            CreateNewPig();
        }
    }
}
