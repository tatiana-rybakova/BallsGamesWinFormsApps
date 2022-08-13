namespace Balls.Common
{
    public class BillyardBall : RandomMoveBall
    {
        public event EventHandler<HitEventArgs> OnHited;

        public BillyardBall(Form form) : base(form)
        {            
        }
        public BillyardBall(Form form, Brush sentBrush, int leftX, int rightX) : base(form)
        {
            brush = sentBrush;
            centerX = random.Next(leftX+radius, rightX - radius);
        }

        protected override void Go()
        {
            base.Go();
            if(centerX <= LeftSide())
            {
                centerX = LeftSide();
                vx = -vx;
                OnHited.Invoke(this, new HitEventArgs(Side.Left));
            }

            if(centerX >= RightSide())
            {
                centerX = RightSide();
                vx = -vx;
                OnHited.Invoke(this, new HitEventArgs(Side.Right));
            }

            if (centerY <= TopSide())
            {
                centerY = TopSide();
                vy = -vy;
                OnHited.Invoke(this, new HitEventArgs(Side.Top));
            }
            if (centerY >= DownSide())
            {
                centerY = DownSide();
                vy = -vy;
                OnHited.Invoke(this, new HitEventArgs(Side.Down));
            }
        }
    }
}
