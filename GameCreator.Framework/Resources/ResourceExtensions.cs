using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework
{
    public static class ResourceExtensions
    {
        #region Objects
        public static Object Define(this IndexedResourceManager<Object> manager)
        {
            return new Object(manager.Context);
        }

        public static Object Define(this IndexedResourceManager<Object> manager, string name)
        {
            return new Object(manager.Context, name);
        }

        public static Object Define(this IndexedResourceManager<Object> manager, string name, int index)
        {
            return new Object(manager.Context, name, index);
        }
        #endregion

        #region Sprites
        public static Sprite Define(this IndexedResourceManager<Sprite> manager, string name, int subimages)
        {
            return new Sprite(manager.Context, name, subimages);
        }

        public static Sprite Define(this IndexedResourceManager<Sprite> manager, string name, int index, int subimages)
        {
            return new Sprite(manager.Context, name, index, subimages);
        }
        #endregion

        #region Scripts
        public static Script Define(this IndexedResourceManager<Script> manager)
        {
            return new Script(manager.Context);
        }

        public static Script Define(this IndexedResourceManager<Script> manager, string name, string code)
        {
            return new Script(manager.Context, name, code);
        }

        public static Script Define(this IndexedResourceManager<Script> manager, string name, int index, string code)
        {
            return new Script(manager.Context, name, index, code);
        }
        #endregion

        #region Rooms
        public static Room Define(this IndexedResourceManager<Room> manager)
        {
            return new Room(manager.Context);
        }

        public static Room Define(this IndexedResourceManager<Room> manager, string name)
        {
            return new Room(manager.Context, name);
        }

        public static Room Define(this IndexedResourceManager<Room> manager, string name, int index)
        {
            return new Room(manager.Context, name, index);
        }
        #endregion
    }
}
