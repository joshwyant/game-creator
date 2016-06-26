using App.Contracts;
using System.Collections.Generic;

namespace App.Resources
{
    public class AppPath : NamedResource, IAppPath
    {
        public override string DefaultPrefix { get { return "path"; } }

        public PathKind ConnectionKind { get; set; }
        public bool IsClosed { get; set; }
        public List<PathVertex> Points { get; set; }
        public int Precision { get; set; }
        public int RoomReference { get; set; }
        public int SnapX { get; set; }
        public int SnapY { get; set; }
    }
}
