using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balls.Common
{

    public class FruitBall : RandomSpeedBall
    {
        private float g = 0.2F;
        public FruitBall(Form form) : base(form)
        {
            radius = random.Next(20, 33);
            vy = (float)random.NextDouble() * -6 - 7;
            centerY = form.ClientSize.Height + radius;
        }
        protected override void Go()
        {
            base.Go();
            vy += g;

            if (centerY > DownSide() + radius*2)
            {
                Stop();
            }
        }

        public void GoSlow()
        {
            timer.Interval = 35;

        }
    }


}
