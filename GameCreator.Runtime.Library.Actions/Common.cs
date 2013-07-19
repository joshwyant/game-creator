using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Runtime.Game;

namespace GameCreator.Runtime.Library.Actions
{
    public static partial class LibraryFunctions
    {
        public GameInstance Current
        {
            get
            {
                return ExecutionContext.Current;
            }
        }
    }
}
