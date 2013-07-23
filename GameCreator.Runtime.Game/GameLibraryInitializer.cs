using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Framework;
using GameCreator.Runtime.Library;
using System.Reflection;
using GameCreator.Runtime.Game.Library.Actions;
using GameCreator.Runtime.Game.Library;

namespace GameCreator.Runtime.Game
{
    public class GameLibraryInitializer : DefaultInitializer
    {
        public override IEnumerable<string> GlobalVariables
        {
            get
            {
                return base.GlobalVariables.Union(new string[] { 

                });
            }
        }

        public override IEnumerable<KeyValuePair<string, Value>> Constants
        {
            get
            {
                return base.Constants.Union(new KeyValuePair<string, Value>[] {

                });
            }
        }

        public override IEnumerable<string> InstanceVariables
        {
            get
            {
                return base.InstanceVariables.Union(new[] { 
                    "alarm", "direction", "speed", "hspeed", "vspeed", "sprite_index", "image_blend",
                    "x", "y", "gravity", "gravity_direction", "friction", "depth", "image_speed", "image_single", "image_index",
                    "image_xscale", "image_yscale", "image_angle", "image_alpha", "xstart", "ystart", "xprevious", "yprevious",
                     "visible", "solid", "persistent",
                });
            }
        }

        public override IEnumerable<Type> FunctionLibraries
        {
            get
            {
                var windowsLibrary = Assembly.Load("GameCreator.Runtime.Library.Windows");

                return base.FunctionLibraries.Union(new Type[] {
                    typeof(LibraryFunctions),
                    typeof(GameFunctions),
                    typeof(FormsFunctions), // Experimental
                    windowsLibrary.GetType("GameCreator.Runtime.Library.Windows.WindowsFunctions"),
                });
            }
        }

        public override IFunction TransformFunction(System.Reflection.MethodInfo m, string n)
        {
            return base.TransformFunction(m, n);
        }

        public override IInstanceFactory CreateInstanceFactory(LibraryContext context)
        {
            return new GameInstanceFactory(context);
        }
    }
}
