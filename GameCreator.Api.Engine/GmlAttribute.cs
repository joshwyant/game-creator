using System;

namespace GameCreator.Api.Engine
{
    public class GmlAttribute : Attribute
    {
        public string? Name { get; }
        public GameMakerVersion MinVersion { get; }
        
        public GmlAttribute(string? name = null, GameMakerVersion minVersion = GameMakerVersion.Any, GameMakerVersion maxVersion = GameMakerVersion.Any)
        {
            Name = name;
            MinVersion = minVersion;
            MaxVersion = maxVersion;
        }
    }
}