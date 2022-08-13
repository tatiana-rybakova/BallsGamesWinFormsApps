using Balls.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryBirdsWinFormsApp
{
    public class Pig : RandomPointBall
    {
        public Pig(Form form) : base(form)
        {
            centerX = random.Next(RightSide() / 2, RightSide() - radius);
            brush = Brushes.Green;
            radius = 25;
        }       
    }
}
