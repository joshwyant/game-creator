using System;

namespace GameCreator.Engine
{
    public class GmlAttribute : Attribute
    {
        public string Name { get; }
        
        public GmlAttribute(string name)
        {
            Name = name;
        }
    }
}