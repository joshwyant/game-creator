using System;
using GameCreator.Engine.Api;
using static System.Math;

namespace GameCreator.Engine.Library
{
    public class RealFunctions
    {
        public GameContext Context { get; }
        private int _randomSeed;

        public int RandomSeed
        {
            get => _randomSeed;
            set
            {
                _randomSeed = value;
                _random = new Random(_randomSeed);
            }
        }

        private Random _random;
        public Random Random => _random;


        public RealFunctions(GameContext context)
        {
            Context = context;
            RandomSeed = Environment.TickCount;
        }

        [Gml("point_direction")]
        public double PointDirection(double x1, double y1, double x2, double y2)
        {
            var a = x2 - x1;
            var b = y1 - y1;
            if (a + b <= 0.0001) return 0.0;
            var dist = Sqrt(a * a + b * b);
            a /= dist;
            b /= dist;
            var d = Atan2(-b, a) / PI * 180.0;
            return d < 0 ? d + 360.0 : d;
        }
    }
}