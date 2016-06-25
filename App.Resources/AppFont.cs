using App.Contracts;

namespace App.Resources
{
    public class AppFont : NamedResource, IAppFont
    {
        public override string DefaultPrefix { get { return "font"; } }
    }
}
