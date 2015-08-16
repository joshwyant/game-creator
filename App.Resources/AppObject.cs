using App.Contracts;

namespace App.Resources
{
    public class AppObject : NamedResource, IAppObject
    {
        public override string DefaultPrefix { get { return "object"; } }
    }
}
