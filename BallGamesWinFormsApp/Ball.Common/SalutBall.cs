namespace Balls.Common
{
    public class SalutBall : Ball
    {
        private float g  = 0.2f;        
        public SalutBall(Form form, float centerX, float centerY) : base(form)
        {
            radius = 10;
            this.centerX = centerX;
            this.centerY = centerY;            
            vx = random.Next(-5, 6);
            vy = -Math.Abs(random.Next(-5, 6));
            while (vx == 0 || vy == 0)
            {
                vx = random.Next(-5, 6);
                vy = random.Next(-5, 6);
            }
        }

        protected override void Go()
        {
            base.Go();
            vy += g;
        }      

    }
}
