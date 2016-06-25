using App.Contracts;

namespace App.Resources
{
    public class AppPath : NamedResource, IAppPath
    {
        public override string DefaultPrefix { get { return "path"; } }
    }
}
