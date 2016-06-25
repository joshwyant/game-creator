using App.Contracts;

namespace App.Resources
{
    public class AppSound : NamedResource, IAppSound
    {
        public override string DefaultPrefix { get { return "sound"; } }
    }
}
