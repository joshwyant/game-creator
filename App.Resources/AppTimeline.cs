using App.Contracts;

namespace App.Resources
{
    public class AppTimeLine : NamedResource, IAppTimeline
    {
        public override string DefaultPrefix { get { return "timeline"; } }
    }
}
