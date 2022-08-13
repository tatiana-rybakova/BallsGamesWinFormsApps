﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balls.Common
{
    public class BananaBall : FruitBall
    {
        public BananaBall(Form form) : base(form)
        {
            brush = Brushes.Yellow;            
        }
    }
}
