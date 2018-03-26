using System.Collections.Generic;

namespace GameCreator.Projects.GMFiles
{
    public class TreeResourceHeader
    {
        public TreeResourceStatus Status { get; set; }
        public TreeResourceKind Grouping { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}