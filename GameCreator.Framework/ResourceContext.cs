using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework
{
    public class ResourceContext
    {
        public LibraryContext Context { get; set; }
        public IEnumerable<string> Scripts { get; set; }

        public ResourceContext(LibraryContext context)
        {
            Context = context;
        }

        public bool FunctionExists(string n)
        {
            return (Context.FunctionExists(n) || Scripts.Contains(n));
        }
    }
}
