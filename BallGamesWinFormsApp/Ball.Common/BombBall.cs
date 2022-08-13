using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balls.Common
{
    public class BombBall : FruitBall
    {
        public BombBall(Form form) : base(form)
        {
            brush = Brushes.Black;
        }
    }
}
