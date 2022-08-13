using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balls.Common
{
    public class RandomSpeedBall : RandomPointBall
    {
        public RandomSpeedBall(Form form) : base(form)
        {
            vx = random.Next(-5, 5);
            vy = random.Next(-5, 5);
            while (vx == 0 && vy == 0)
            {
                vx = random.Next(-5, 5);
                vy = random.Next(-5, 5);
            }
        }
    }
}
