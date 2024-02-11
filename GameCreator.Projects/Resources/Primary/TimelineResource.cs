using System.Collections.Generic;

namespace GameCreator.Projects
{
    public class TimelineResource : BaseResource
    {
        public SortedDictionary<int, List<ActionEntry>> Moments { get; set; }
    }
}