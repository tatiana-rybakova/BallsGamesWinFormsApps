using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balls.Common
{
    public class VerticalBall : SalutBall
    {
        public event EventHandler<TopReachedEventArgs> TopReached;
        public VerticalBall(Form form) : base(form, form.ClientSize.Width / 2, form.ClientSize.Height)
        {
            vy = (float)random.NextDouble() * -6 - 7;
            vx = 0;
        }
        protected override void Go()
        {
            base.Go();

            if(vy>0)
            {
                Stop();
                Clear();
                TopReached?.Invoke(this, new TopReachedEventArgs(centerX, centerY));
            }    
        }
    }
}
