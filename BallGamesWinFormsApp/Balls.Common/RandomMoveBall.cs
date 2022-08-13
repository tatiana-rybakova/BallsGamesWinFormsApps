using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balls.Common
{
    public class RandomMoveBall : MoveBall
    {
        public RandomMoveBall(MainForm form) : base(form)
        {
            vx = random.Next(-1, 1);
            vy = random.Next(-1, 1);
            while (vx == 0 && vy == 0)
            {
                vx = random.Next(-1, 1);
                vy = random.Next(-1, 1);
            }
        }
    }
}
