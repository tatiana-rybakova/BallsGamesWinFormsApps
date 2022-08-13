using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balls.Common
{
    public class TopReachedEventArgs
    {
        public float CenterX;
        public float CenterY;

        public TopReachedEventArgs(float centerX, float centerY)
        {
            CenterX = centerX;
            CenterY = centerY;
        }
    }
}
