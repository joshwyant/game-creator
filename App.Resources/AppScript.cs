using App.Contracts;

namespace App.Resources
{
    public class AppScript : NamedResource, IAppScript
    {
        public override string DefaultPrefix { get { return "script"; } }

        public string Code { get; set; }
    }
}
