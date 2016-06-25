using App.Contracts;

namespace App.Resources
{
    public class AppBackground : NamedResource, IAppBackground
    {
        public override string DefaultPrefix { get { return "background"; } }
    }
}
