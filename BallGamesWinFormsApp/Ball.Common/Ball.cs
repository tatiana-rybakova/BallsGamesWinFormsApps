using Timer = System.Windows.Forms.Timer;

namespace Balls.Common
{
    public class Ball
    {
        private Form form;
        protected Timer timer;

        protected float centerX = 150;
        protected float centerY = 150;
        protected float vx = 1;
        protected float vy = 1;
        protected int radius = 15;        
        protected static Random random = new Random(); 
        public Brush brush = Brushes.Aqua;        
        

        public Ball(Form form)
        {
            this.form = form;
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Move();
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }
        public bool IsMoving()
        {
            return timer.Enabled;
        }        
        protected virtual void Go()
        {
            centerX += vx;
            centerY += vy;
        }
        public void Clear()
        {            
            var brush = Brushes.White;
            Show(brush);
        }

        public void Move()
        {
            Clear();
            Go();
            Show(brush);
        }

        public bool IsLeft()
        {
            return centerX + radius < form.ClientSize.Width / 2;
        }

        public bool IsRight()
        {
            return centerX + radius > form.ClientSize.Width / 2;
        }

        public int LeftSide()
        {
            return radius;
        }

        public int RightSide()
        {
            return form.ClientSize.Width - radius;
        }
        public int TopSide()
        {
            return radius;
        }
        public int DownSide()
        {
            return form.ClientSize.Height - radius;

        }

        public bool Catched()
        {
            return centerX > LeftSide() && centerX < RightSide() && centerY > TopSide() && centerY < DownSide();
        }

        public bool Contains(int pointX, int pointY)
        {  
            var dx = pointX - centerX;
            var dy = pointY - centerY;
            return dx * dx + dy * dy <= radius * radius;
        }

        public void Show(Brush brush)
        {
            var graphics = form.CreateGraphics();
            var rectangle = new RectangleF(centerX - radius, centerY - radius, radius * 2, radius * 2);
            graphics.FillEllipse(brush, rectangle);
        }     
        
        public float GetX()
        {
            return centerX;
        }

        public float GetY()
        {
            return centerY;
        }

        public bool IsTouching(Ball pig)
        {
            var dx = centerX - pig.centerX;
            var dy = centerY - pig.centerY;
            return dx * dx + dy * dy <= Math.Pow(radius + pig.radius, 2);
        }
    }
}
