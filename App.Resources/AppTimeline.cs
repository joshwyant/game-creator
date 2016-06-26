using App.Contracts;
using System.Collections.Generic;

namespace App.Resources
{
    public class AppTimeline : NamedResource, IAppTimeline
    {
        public Dictionary<int, List<IAppAction>> Moments { get; set; }

        public override string DefaultPrefix { get { return "timeline"; } }
    }
}
