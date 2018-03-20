using System;

namespace GameCreator.Engine.Api
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