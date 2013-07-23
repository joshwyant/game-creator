using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Framework;

namespace GameCreator.Runtime.Game
{
    public class GameInstanceFactory : DefaultInstanceFactory
    {
        public GameInstanceFactory(LibraryContext context)
            : base(context) { }

        public override Instance CreateInstance(int object_index)
        {
            return new GameInstance(Context.Resources, object_index, -1);
        }

        public override Instance CreateInstance(int object_index, int id)
        {
            return new GameInstance(Context.Resources, object_index, id);
        }

        public override Instance CreatePrivateInstance()
        {
            return new GameInstance(Context.Resources);
        }
    }
}
