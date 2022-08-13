using System.Windows.Forms

namespace Balls.Common
{
    public class Ball
    {
        protected int x = 150;
        protected int y = 150;
        protected int vx = 1;
        protected int vy = 1;
        protected int size = 50;
        protected Form form;
        protected static Random random = new Random();

        public Ball (Form form)
        {          
            this.form = form;
        }
        public void Show()
        {
            var graphics = form.CreateGraphics();
            var brush = Brushes.Aqua;
            var rectangle = new Rectangle(x, y, size, size);
            graphics.FillEllipse(brush, rectangle);
        }

        public void Go()
        {          
            x += vx;
            y += vy;
        }
        public void Clear()
        {
            var graphics = form.CreateGraphics();
            var brush = Brushes.White;
            var rectangle = new Rectangle(x, y, size, size);
            graphics.FillEllipse(brush, rectangle);
        }

        public void Move()
        {
            Clear();
            Go();
            Show();
        }

        public bool Catched()
        {
            return x > 0 && x < form.ClientSize.Width - 70 && y > 0 && y < form.ClientSize.Height - 70;            
        }
    }
}
