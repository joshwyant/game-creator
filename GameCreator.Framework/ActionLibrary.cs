using System.Collections.Generic;

namespace GameCreator.Framework
{
    public class ActionLibrary
    {
        public LibraryContext Context { get; set; }

        internal Dictionary<int, ActionDefinition> Actions = new Dictionary<int, ActionDefinition>();
        int ID { get; set; }
        internal ActionLibrary(LibraryContext lib, int id) { Context = lib;  ID = id; }
    }
}
