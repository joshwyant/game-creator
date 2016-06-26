using App.Contracts;

namespace App.Resources
{
    public class AppTimeline : NamedResource, IAppTimeline
    {
        public override string DefaultPrefix { get { return "timeline"; } }
    }
}
