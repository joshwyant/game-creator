namespace GameCreator.Projects
{
    public struct PathVertex
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Speed { get; set; }

        public PathVertex(double x, double y, double speed)
        {
            X = x;
            Y = y;
            Speed = speed;
        }
    }
}