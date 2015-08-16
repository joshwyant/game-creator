using App.Contracts;

namespace App.Resources
{
    public class AppRoom : NamedResource, IAppRoom
    {
        public override string DefaultPrefix { get { return "room"; } }
    }
}
