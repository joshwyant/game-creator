using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Runtime.Game.Library.Actions
{
    public static partial class LibraryFunctions
    {
        public static GameInstance Current
        {
            get
            {
                return ExecutionContext.Current as GameInstance;
            }
        }
    }
}
