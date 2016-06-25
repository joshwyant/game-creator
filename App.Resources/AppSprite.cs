using App.Contracts;

namespace App.Resources
{
    public class AppSprite : NamedResource, IAppSprite
    {
        public override string DefaultPrefix { get { return "sprite"; } }
    }
}
