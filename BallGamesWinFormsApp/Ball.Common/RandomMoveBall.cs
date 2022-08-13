using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balls.Common
{
    public class RandomMoveBall : RandomPointBall
    {
        public RandomMoveBall(Form form) : base(form)
        {
            vx = random.Next(-1, 2);
            vy = random.Next(-1, 2);
            while (vx == 0 || vy == 0)
            {
                vx = random.Next(-1, 2);
                vy = random.Next(-1, 2);
            }           
        }
    }
}
