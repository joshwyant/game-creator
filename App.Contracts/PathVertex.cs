using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Contracts
{
    public struct PathVertex
    {
        public double X;
        public double Y;
        public double Speed;

        public PathVertex(double x, double y, double speed)
        {
            X = x;
            Y = y;
            Speed = speed;
        }
    }
}
