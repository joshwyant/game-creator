using System;

namespace GameCreator.Engine
{
    public class PredefinedInstance
    {
        public int Id { get; }
        public int X { get; }
        public int Y { get; }
        public GameObject GameObject { get; }
        
        public PredefinedInstance(int id, int x, int y, GameObject gameObject)
        {
            if (id < 100001)
            {
                throw new ArgumentOutOfRangeException("id");
            }

            Id = id;
            X = x;
            Y = y;
            GameObject = gameObject ?? throw new ArgumentNullException("gameObject");
        }
    }
}