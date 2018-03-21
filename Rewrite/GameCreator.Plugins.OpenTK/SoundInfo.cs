using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using GameCreator.Engine.Api;

namespace GameCreator.Plugins.OpenTK
{
    public class SoundInfo : ISoundEffect
    {
        public SoundInfo(int bufferId, TimeSpan length)
        {
            BufferId = bufferId;
            Length = length;
            Sources = new ConcurrentDictionary<int, Source>();
        }
        
        public int BufferId { get; }
        public TimeSpan Length { get; }
        public ConcurrentDictionary<int, Source> Sources { get; }

        public bool IsPlaying()
        {
            return Sources.Any(s => s.Value.IsPlaying());
        }
    }
}