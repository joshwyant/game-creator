using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Framework;
using System.Reflection;
using System.Linq.Expressions;

namespace GameCreator.Runtime.Game.Jited
{
    public class JitedGameLibraryInitializer : GameLibraryInitializer
    {
        public override IEnumerable<Type> FunctionLibraries
        {
            get
            {
                return base.FunctionLibraries;
            }
        }

        public override IFunction TransformFunction(System.Reflection.MethodInfo m, string n)
        {
            return new BaseFunction(n, -1, m);
        }

        public override void PerformEvent(Instance e, EventType et, int num)
        {
            var events = e.Context.Objects[e.ObjectIndex].Events;

            if (events.ContainsKey(et))
            {
                var ee = events[et];
                //if (ee.ContainsKey(num))
                //    ee[num].Execute();
            }
        }
    }
}
