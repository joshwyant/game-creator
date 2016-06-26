using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Contracts.Services
{
    public class TreeResource
    {
        public TreeResourceStatus Status { get; set; }
        public TreeResourceKind Grouping { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public List<TreeResource> Contents { get; set; }
    }
}
