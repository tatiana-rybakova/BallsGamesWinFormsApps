using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balls.Common
{
    public class HitEventArgs
    {
        public Side Side { get; set; }
        public HitEventArgs(Side side)
        {
            Side = side;
        }
    }
}
