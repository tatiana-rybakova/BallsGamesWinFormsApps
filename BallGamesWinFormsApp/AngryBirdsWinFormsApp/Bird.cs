using Balls.Common;

namespace AngryBirdsWinFormsApp
{
    public class Bird : Ball
    {
        private float g = 0.2f;
        private float elastic = 0.4f;
        public Bird(Form form) : base(form)
        {
            timer.Interval = 25;
            centerX = LeftSide();
            centerY = DownSide();
            brush = Brushes.Red;            
        }

        protected override void Go()
        {
            base.Go();

            if (centerY >= DownSide())
            {
                vy = -vy;
                centerY = DownSide();
                vy = vy * elastic;
                vx = vx * elastic;
            }           
            vy += g;

            

            if (vx < 0.3 && vy < 0.3)
            {
                Stop();
            }
        }

        public void SetSpeed(int x, int y)
        {
            vx = (x - centerX) / 25;
            vy = (y - centerY) / 25;
        }

        public bool IsOutSide()
        {
            return centerX > RightSide();
        }       
    }
}
