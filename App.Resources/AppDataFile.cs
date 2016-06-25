using App.Contracts;

namespace App.Resources
{
    public class AppDataFile : NamedResource, IAppDataFile
    {
        public override string DefaultPrefix { get { return "datafile"; } }
    }
}
