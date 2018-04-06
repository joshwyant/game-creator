using System;

namespace GameCreator.Runtime.Api
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