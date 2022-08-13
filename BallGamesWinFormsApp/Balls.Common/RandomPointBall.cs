using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balls.Common
{
    public class RandomPointBall : Ball
    {
        Random random = new Random();

        public RandomPointBall(MainForm form): base(form)
        {
            x = random.Next(0, form.ClientSize.Width-size);
            y = random.Next(0, form.ClientSize.Height-size);
        }
    }
}
