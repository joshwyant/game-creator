using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Framework;
using GameCreator.Framework.Gml.Interpreter;
using System.Reflection;

namespace GameCreator.Runtime.Game.Interpreted
{
    class InterpretedGameLibraryInitializer : GameLibraryInitializer
    {
        public override IEnumerable<Type> FunctionLibraries
        {
            get
            {
                var asm = Assembly.Load("GameCreator.Runtime.Library.Interpreted");
                return base.FunctionLibraries.Union(new [] {
                    asm.GetType("GameCreator.Runtime.Library.Interpreted.InterpreterFunctions"),
                });
            }
        }

        public override BaseFunction TransformFunction(System.Reflection.MethodInfo m, string n)
        {
            var parms = m.GetParameters();
            var argc = parms.Length;
            if (argc == 1 && parms.Any(p => p.GetCustomAttributes(typeof(ParamArrayAttribute), false).Any() && p.ParameterType == typeof(Value[])))
                argc = -1;

            var input = System.Linq.Expressions.Expression.Parameter(typeof(Value[]));

            var e_params = parms.Select(
                (p, i) =>
                {
                    System.Linq.Expressions.Expression param = System.Linq.Expressions.Expression.ArrayAccess(input, System.Linq.Expressions.Expression.Constant(i));
                    if (argc == -1)
                        return input;
                    if (p.ParameterType.IsAssignableFrom(typeof(Value)))
                        return param;
                    return System.Linq.Expressions.Expression.Convert(param, p.ParameterType);
                }
                );

            var call = System.Linq.Expressions.Expression.Call(m, e_params);

            System.Linq.Expressions.Expression body;

            if (m.ReturnType == typeof(void))
            {
                body = System.Linq.Expressions.Expression.Block(
                    call,
                    System.Linq.Expressions.Expression.Property(null, typeof(Value).GetProperty("Null", System.Reflection.BindingFlags.Static))
                );
            }
            else
            {
                if (typeof(Value).IsAssignableFrom(m.ReturnType))
                    body = call;
                else
                    body = System.Linq.Expressions.Expression.Convert(call, typeof(Value));
            }

            FunctionDelegate del = System.Linq.Expressions.Expression.Lambda<FunctionDelegate>(body, input).Compile();

            return new Function(n, argc, del);
        }
    }
}
